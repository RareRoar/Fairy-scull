
using UnityEngine;

public class ChaosBehavior : MonoBehaviour
{
    private float timer_;
    public GameObject projectile;
    public float haste;
    public float velocity;
    
    void Awake()
    {
        timer_ = 0.0f;
    }

    void Update()
    {
        if (Time.time > timer_)
        {
            timer_ += haste;

            GameObject[] shots = new GameObject[8];
            for (int i = 0; i < 8; i++)
            {
                shots[i] = Instantiate(projectile, transform.position, transform.rotation);
            }

            float SQR = Mathf.Sqrt((float)0.5);
            Vector2[] directions = new Vector2[8] { Vector2.up, new Vector2(SQR, SQR), Vector2.right,
                                                    new Vector2(SQR, -SQR), Vector2.down, new Vector2(-SQR, -SQR),
                                                    Vector2.left, new Vector2(-SQR, SQR)};

            for (int i = 0; i < 8; i++)
            {
                shots[i].GetComponent<Rigidbody2D>().AddForce(directions[i] * velocity, ForceMode2D.Impulse);
            }
        }
    }
}

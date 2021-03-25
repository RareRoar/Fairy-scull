
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    private float timer;
    public float haste;
    public float velocity;

    public GameObject projectile;

    private void Awake()
    {
        timer = 0.0f;
    }
    
    private void Update()
    {
        if (Time.time > timer)
        {
            timer += haste;
            GameObject[] shots = new GameObject[4];
            for (int i = 0; i < 4; i++)
            {
                shots[i] = Instantiate(projectile, transform.position, transform.rotation);
            }

            Vector2[] directions = new Vector2[4] { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

            for (int i = 0; i < 4; i++)
            {
                shots[i].GetComponent<Rigidbody2D>().AddForce(directions[i] * velocity, ForceMode2D.Impulse);
            }
        }
    }
}


using UnityEngine;

public class WallEyeBehavior : MonoBehaviour
{
    private float timer;
    public GameObject projectile;
    public GameObject pupil;
    public float haste;
    public float velocity;
    
    private void Awake()
    {
        timer = 0.0f;
    }
    
    private void Update()
    {

        if (Time.time > timer)
        {
            timer += haste;
            GameObject shot = Instantiate(projectile, pupil.transform.position, pupil.transform.rotation);

            shot.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(pupil.transform.position.x - transform.position.x, 
                pupil.transform.position.y - transform.position.y).normalized *
                velocity, ForceMode2D.Impulse);

        }
    }
}

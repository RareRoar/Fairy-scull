
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    private float timer_;
    private Animator animator_;
    public GameObject death;
    
    void Start()
    {
        timer_ = 0.0f;
        animator_ = gameObject.GetComponent<Animator>();
        animator_.enabled = false;
    }
    
    void Update()
    {
        if (timer_ >= 0.5f)
        {
            Destroy(gameObject);
        }

        if (health <= 0)
        {
            death.SendMessageUpwards("DeathAnima");

            animator_.enabled = true;
            timer_ += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger && collision.CompareTag("Attack"))
        {
            health -= 1;
        }
    }
}


using UnityEngine;

public class Hurt : MonoBehaviour
{
    private Animator animator_;
    private float timer_;
    public int maxHealth;
    public int curHealth;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger && collision.CompareTag("Shot"))
        {
            timer_ = 0.0f;

            Destroy(collision.gameObject);
            animator_.SetBool("hurt", true);

            if (curHealth > 0)
            {
                curHealth--;
            }
            else
            {
                curHealth = 0;
            }
        }
    }

    void Start()
    {
        maxHealth = 10;
        curHealth = 10;

        animator_ = GetComponent<Animator>();
        animator_.SetBool("hurt", false);
    }

    void Update()
    {
        if (animator_.GetBool("hurt"))
        {
            timer_ += Time.deltaTime;
            if (timer_ >= 0.3)
            {
                animator_.SetBool("hurt", false);
            }
        }
        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

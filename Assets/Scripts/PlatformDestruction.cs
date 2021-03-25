
using UnityEngine;

public class PlatformDestruction : MonoBehaviour
{
    private bool pressure;
    private Animator animator_;
    private BoxCollider2D collider_;

    public float delay;
    public float replenishment;
    private float start_;
    private float timer_;

    void Start()
    {
        pressure = false;
        collider_ = GetComponent<BoxCollider2D>();
        animator_ = GetComponent<Animator>();
        animator_.SetBool("pressure", false);
    }

    void Update()
    {
        if (pressure)
        {
            timer_ += Time.deltaTime;
            if (timer_ - start_ >= delay)
            {
                pressure = false;
                collider_.enabled = false;

                start_ = Time.time;
                timer_ = start_;
            }
        }    
        else
        {
            if (!collider_.enabled)
            {
                timer_ += Time.deltaTime;
                if (timer_ - start_ >= replenishment)
                {
                    collider_.enabled = true;
                    animator_.SetBool("pressure", false);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colission)
    {
        if (!pressure && collider_.enabled)
        {
            if (colission.CompareTag("Player"))
            {
                pressure = true;
                animator_.SetBool("pressure", true);

                start_ = Time.time;
                timer_ = start_;
            }
        }
    }
}


using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 250.0f;
    public float jumpForce = 12.0f;

    private BoxCollider2D box_;
    private Rigidbody2D body_;
    protected Animator animator_;

    public bool attacking;
    private float timer_;
    public float attackDur;

    private float delay_;
    
    private void Start()
    {
        delay_ = 0.0f;
        
        animator_ = GetComponent<Animator>();
        box_ = GetComponent<BoxCollider2D>();
        body_ = GetComponent<Rigidbody2D>();

        animator_.SetBool("attacking", false);
    }

    private void Update()
    {
        if (delay_ < 0.2f)
        {
            delay_ += Time.deltaTime;
            GameObject[] shots = GameObject.FindGameObjectsWithTag("Shot");
            for (int i = 0; i < shots.Length; i++)
            {
                Destroy(shots[i]);
            }
        }

        animator_.SetBool("jump", false);

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator_.SetBool("attacking", true);
            timer_ = 0.0f;
        }

        if (animator_.GetBool("attacking"))
        {
            timer_ += Time.deltaTime;
            if (timer_ >= attackDur)
            {

                animator_.SetBool("attacking", false);
            }
        }

        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, body_.velocity.y);
        body_.velocity = movement;

        if (body_.transform.position.y < -10.0f)
        {
           body_.transform.position = new Vector3(-3.0f, 3.0f, body_.transform.position.z);
        }

        Vector3 max = box_.bounds.max;
        Vector3 min = box_.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x, min.y - 0.2f);

        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
        bool grounded = false;

        if (hit != null)
        {
            grounded = true;
        }

        body_.gravityScale = grounded && deltaX == 0 ? 0 : 1;

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            body_.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator_.SetBool("jump", true);
        }

        animator_.SetFloat("speed", Mathf.Abs(deltaX));

        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }    
    }
}

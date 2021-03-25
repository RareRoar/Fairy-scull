
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timer_;
    public float attackDur = 0.2f;
    private CircleCollider2D _circle;
    
    private void Start()
    {
        _circle = GetComponent<CircleCollider2D>();
        _circle.enabled = false;
    }

    private void Update()
    {
        if(_circle.enabled)
        {
            timer_ += Time.deltaTime;
            if (timer_ >= attackDur)
            {
                _circle.enabled = false;

            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            timer_ = 0.0f;
            _circle.enabled = true;
        }
    }
}

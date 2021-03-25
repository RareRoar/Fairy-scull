
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animator_;
    
    private void Start()
    {
        animator_ = GetComponent<Animator>();
        animator_.enabled = false;
    }
    
    private void DeathAnima()
    {
        animator_.enabled = true;
    }
}

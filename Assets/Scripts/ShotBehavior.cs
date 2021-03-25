
using UnityEngine;

public class ShotBehavior : MonoBehaviour
{
    public float lifeTime = 2.0f;
    private float _start;
    
    private void Start()
    {
        _start = Time.time;
    }
    
    private void Update()
    {
        if (Time.time - (_start + lifeTime) >= 0)
        {
            Destroy(gameObject);
        }
    }
}

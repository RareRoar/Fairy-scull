using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingEyeBehavior : MonoBehaviour
{
    private float timer;
    public float haste;
    public float velocity;

    public GameObject projectile;
    public GameObject pupil;
    
    private void Awake()
    {
        timer = 0.0f;
    }
    
    private void Update()
    {
        if (Time.time > timer)
        {
            transform.Rotate(Vector3.forward * -20.0f);
            timer += haste;

            GameObject shot = Instantiate(projectile, pupil.transform.position, pupil.transform.rotation);
            shot.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(pupil.transform.position.x - transform.position.x,
                            pupil.transform.position.y - transform.position.y).normalized *
                            velocity, ForceMode2D.Impulse);
        }
    }
}

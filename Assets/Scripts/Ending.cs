
using UnityEngine;

public class Ending : MonoBehaviour
{
    private static bool victory_;
    private GameObject music_;
    public AudioClip righteousMelody;

    private void Start()
    {
        music_ = GameObject.FindGameObjectWithTag("Music");
        Destroy(music_);

        GameObject sadMusic = new GameObject();
        sadMusic.AddComponent<AudioSource>();
        AudioSource audioSource = sadMusic.GetComponent<AudioSource>();
        audioSource.PlayOneShot(righteousMelody);

        victory_ = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger && collision.CompareTag("Attack"))
        {
            victory_ = true;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    public static bool IsVictorious()
    {
        if (victory_)
        {
            victory_ = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}

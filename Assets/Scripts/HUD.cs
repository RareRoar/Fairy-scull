
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] healthSprites;

    public Image healthBar;
    public Image deathScreen;
    public Image hint;
    public Image victory;
    public Image pause;

    private AudioSource audioSource_;
    private Hurt player_;
    private GameObject music_;
    public AudioClip sadMelody;

    private bool pause_ = false;

    private void Start()
    {
        pause.enabled = false;
        victory.enabled = false;
        deathScreen.enabled = false;
        hint.enabled = false;

        player_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Hurt>();
        audioSource_ = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
    }

    IEnumerator LoadLevelAfterDelay()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Menu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause_)
            {
                audioSource_.Play();
                Time.timeScale = 1;
            }
            else
            {
                audioSource_.Pause();
                Time.timeScale = 0;
            }
            pause_ = !pause_;
            pause.enabled = pause_;
        }
    }

    public void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Ending.IsVictorious())
        {
            victory.enabled = true;
            StartCoroutine("LoadLevelAfterDelay");
        }

        if (player_.curHealth <= 0)
        {
            music_ = GameObject.FindGameObjectWithTag("Music");
            Destroy(music_);

            GameObject sadMusic = new GameObject();
            sadMusic.AddComponent<AudioSource>();
            AudioSource audioSource = sadMusic.GetComponent<AudioSource>();
            audioSource.PlayOneShot(sadMelody);

            healthBar.sprite = healthSprites[9];
            deathScreen.enabled = true;
            hint.enabled = true;            
        }
        else
        {
            healthBar.sprite = healthSprites[10 - player_.curHealth];
        }
    }
}

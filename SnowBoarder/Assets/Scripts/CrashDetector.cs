using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] GameObject crashBubble;
    [SerializeField] ParticleSystem crashSnowEffect;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip owAudio;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float soundGap = 0.2f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (audioSource)
            {
                StartCoroutine(PlayCrashSounds());
            }

            if (crashBubble != null && crashSnowEffect != null)
            {
                crashSnowEffect.Play();
                crashBubble.SetActive(true);
            }

            Invoke("ReloadScene", reloadDelay);
        }
    }

    IEnumerator PlayCrashSounds()
    {
        audioSource.PlayOneShot(crashAudio);
        yield return new WaitForSeconds(soundGap);
        audioSource.PlayOneShot(owAudio);
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

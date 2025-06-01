using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.5f;
    [SerializeField] GameObject crashBubble;
    [SerializeField] ParticleSystem crashSnowEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (crashBubble != null && crashSnowEffect != null)
            {
                crashSnowEffect.Play();
                crashBubble.SetActive(true);
            }

            Invoke("ReloadScene", reloadDelay);
        }
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1.5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Debug.Log("Shit!");
            Invoke("ReloadScene", reloadDelay);
        }
    }


    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}

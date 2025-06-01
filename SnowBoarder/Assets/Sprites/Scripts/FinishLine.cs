using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay = 1f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Invoke("ReloadScene",finishDelay);
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);

    }
}

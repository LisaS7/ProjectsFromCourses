using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    public string nextArea;
    public string areaTransitionName;

    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.instance.areaTransitionName = areaTransitionName;
            SceneManager.LoadScene(nextArea);
        }
    }
}

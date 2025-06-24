using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    public string nextArea;
    public string areaTransitionName;
    public EnterArea theEntrance;

    public float loadTime = 1f;

    private bool shouldLoadAfterFade;

    void Start()
    {
        theEntrance.transitionName = areaTransitionName;
    }


    void Update()
    {
        if (shouldLoadAfterFade)
        {
            loadTime -= Time.deltaTime;
            if (loadTime <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(nextArea);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shouldLoadAfterFade = true;
            UIFade.instance.FadeOut();
            PlayerController.instance.areaTransitionName = areaTransitionName;
            // SceneManager.LoadScene(nextArea);
        }
    }
}

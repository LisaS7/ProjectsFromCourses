using UnityEngine;

public class EnterArea : MonoBehaviour
{
    public string transitionName;

    void Start()
    {
        if (transitionName == PlayerController.instance.areaTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }

        PlayerController.instance.areaTransitionName = "";
        UIFade.instance.FadeIn();
        GameManager.instance.fadeActive = false;
    }


    void Update()
    {

    }
}

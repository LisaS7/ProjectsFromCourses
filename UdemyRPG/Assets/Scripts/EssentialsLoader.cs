using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject player;

    void Start()
    {
        if (UIFade.instance == null)
        {
            UIFade.instance = Instantiate(UICanvas).GetComponent<UIFade>();

        }

        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }
    }


    void Update()
    {

    }
}

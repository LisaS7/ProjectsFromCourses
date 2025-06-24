using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject fadeCanvas;
    public GameObject player;

    void Start()
    {
        if (UIFade.instance == null)
        {
            UIFade.instance = Instantiate(fadeCanvas).GetComponent<UIFade>();

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

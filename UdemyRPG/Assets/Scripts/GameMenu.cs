using UnityEngine;

public class GameMenu : MonoBehaviour
{
    public GameObject menuPanel;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (menuPanel.activeInHierarchy)
            {
                menuPanel.SetActive(false);
                GameManager.instance.menuActive = false;
            }
            else
            {
                menuPanel.SetActive(true);
                GameManager.instance.menuActive = true;
            }
        }
    }
}

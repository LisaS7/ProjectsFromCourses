using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{

    public static UIFade instance;

    public Image fadeScreen;
    public float fadeSpeed;

    bool shouldFadeOut;
    bool shouldFadeIn;

    void Start()
    {
        instance = this;
    }


    void Update()
    {
        if (shouldFadeOut)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1f)
            {
                shouldFadeOut = false;
            }
        }

        if (shouldFadeIn)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeIn = false;
            }

        }
    }

    public void FadeOut()
    {
        shouldFadeOut = true;
        shouldFadeIn = false;
    }

    public void FadeIn()
    {
        shouldFadeIn = true;
        shouldFadeOut = false;
    }
}

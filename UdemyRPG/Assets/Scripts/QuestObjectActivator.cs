using UnityEngine;

public class QuestObjectActivator : MonoBehaviour
{
    public GameObject objectToActivate;
    public string questToCheck;
    public bool activeIfComplete;
    bool initialCheckDone;

    void Start()
    {

    }

    void Update()
    {
        if (!initialCheckDone)
        {
            initialCheckDone = true;
            CheckCompletion();
        }
    }

    public void CheckCompletion()
    {
        if (QuestManager.instance.CheckIfComplete(questToCheck))
        {
            objectToActivate.SetActive(activeIfComplete);
        }
    }
}

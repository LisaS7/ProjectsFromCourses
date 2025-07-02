using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public string[] questMarkerNames;
    public bool[] questMarkersComplete;

    public static QuestManager instance;

    void Start()
    {
        instance = this;
        questMarkersComplete = new bool[questMarkerNames.Length];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CheckIfComplete("Return to town");
        }
    }

    public int GetQuestNumber(string quest)
    {
        for (int i = 0; i < questMarkerNames.Length; i++)
        {
            if (questMarkerNames[i] == quest)
            {
                return i;
            }
        }
        Debug.LogError($"Quest '{quest}' does not exist");
        return 0;
    }

    public bool CheckIfComplete(string quest)
    {
        int index = GetQuestNumber(quest);
        if (index != 0)
        {
            return questMarkersComplete[index];
        }

        return false;
    }

    public void MarkQuestComplete(string quest)
    {
        int index = GetQuestNumber(quest);
        questMarkersComplete[index] = true;
    }

    public void MarkQuestIncomplete(string quest)
    {
        int index = GetQuestNumber(quest);
        questMarkersComplete[index] = false;
    }
}

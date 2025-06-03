using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text";
    [SerializeField] string[] answers = new string[4];

    public string GetQuestion()
    {
        return question;
    }
}

using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] float questionTotalTime = 30f;
    [SerializeField] float answerTotalTime = 10f;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        if (isAnsweringQuestion)
        {
            isAnsweringQuestion = false;
            timerValue = answerTotalTime;
        }

    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / questionTotalTime;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = answerTotalTime;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / answerTotalTime;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = questionTotalTime;
                loadNextQuestion = true;

            }
        }

    }
}

using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public GameObject nextQuestion;

    public void RightAnswer()
    {
        nextQuestion.SetActive(true);
    }
}
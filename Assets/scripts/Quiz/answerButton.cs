using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answerButton : MonoBehaviour
{
    public Text answerText;
    private answerData AnswerData;
    private GameControllerQuiz gamecontroller;

    // Start is called before the first frame update
    void Start()
    {
        gamecontroller = FindObjectOfType<GameControllerQuiz>();     
    }
    public void Setup(answerData data)
    {
        AnswerData = data;
        answerText.text = AnswerData.answerText;
    }
    public void handleClick()
    {
        gamecontroller.AnswerButtonClicked(AnswerData.isCorrect);
    }
}

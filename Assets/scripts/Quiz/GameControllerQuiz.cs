﻿  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerQuiz : MonoBehaviour
{
    public Text displayQuestionText;
    public Transform answerButtonParent;
    public Text displayScoreText;
    public Text lastScore;
    public Text statusDisplay;
    public Text TimeDisplay;
    public SimpleObjectPool answerButtonObjectPool;
    public GameObject StatusDisplay;
    public GameObject QuestionPanelDisplay;
    public GameObject RoundOverPanelDisplay;
    public GameObject StartDisplay;

    private DataController dataCon;
    private RoundData CurrentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private float time;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Start is called before the first frame update

    public void gempaChoice()
    {
        dataCon = FindObjectOfType<DataController>();
        CurrentRoundData = dataCon.getGempa();

        StartDisplay.SetActive(false);
        QuestionPanelDisplay.SetActive(true);

        questionPool = CurrentRoundData.questions;
        time = CurrentRoundData.timeLimitInSeconds; 
        UpdateTime();

        playerScore = 0;
        questionIndex = 0;

        showQuestion();
        isRoundActive = true;
    }
    public void tsunamiChoice()
    {
        dataCon = FindObjectOfType<DataController>();
        CurrentRoundData = dataCon.getTsunami();

        StartDisplay.SetActive(false);
        QuestionPanelDisplay.SetActive(true);

        questionPool = CurrentRoundData.questions;
        time = CurrentRoundData.timeLimitInSeconds;
        UpdateTime();

        playerScore = 0;
        questionIndex = 0;

        showQuestion();
        isRoundActive = true;
    }
    public void gunungApiChoice()
    {
        dataCon = FindObjectOfType<DataController>();
        CurrentRoundData = dataCon.getGunungBerapi();

        StartDisplay.SetActive(false);
        QuestionPanelDisplay.SetActive(true);

        questionPool = CurrentRoundData.questions;
        time = CurrentRoundData.timeLimitInSeconds;
        UpdateTime();

        playerScore = 0;
        questionIndex = 0;

        showQuestion();
        isRoundActive = true;
    }

    private void showQuestion()
    {
        RemoveAnswerButton();
        QuestionData questionData = questionPool[questionIndex];
        displayQuestionText.text = questionData.questionText;
        //get button dan set parent 
        for(int i = 0; i<questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObject.transform.localScale = Vector3.one;
            
            answerButton AnswerButton = answerButtonGameObject.GetComponent<answerButton>();
            AnswerButton.Setup(questionData.answers[i]);
        }
    }
    private void RemoveAnswerButton()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }
    public void AnswerButtonClicked(bool isCorret)
    {
        if (isCorret)
        {
            playerScore += CurrentRoundData.plusScore;
            displayScoreText.text = "" + playerScore.ToString();
            lastScore.text = "" + playerScore.ToString();
            StartCoroutine(ShowStatus("BENAR", 0.5f));
        }
        else
        {
            StartCoroutine(ShowStatus("SALAH", 0.5f));
        }
        if(questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            showQuestion();
        }
        else
        {
            EndGame();
        }
        
    }
    public void EndGame()
    {
        isRoundActive = false;
        QuestionPanelDisplay.SetActive(false);
        RoundOverPanelDisplay.SetActive(true);
    }
 
    IEnumerator ShowStatus(string massage, float delay)
    {
        StatusDisplay.SetActive(true);
        statusDisplay.text = massage;
        yield return new WaitForSeconds(delay);
        StatusDisplay.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    private void UpdateTime()
    {
        TimeDisplay.text = "" + Mathf.Round(time).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            time -= Time.deltaTime;
            UpdateTime();
            if (time <= 0f)
            {
                EndGame();
            }
        }
    }
}

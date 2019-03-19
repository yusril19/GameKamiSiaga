using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class skor : MonoBehaviour
{
    public Text scoreTxt;
    public int itemValue;
    private int score;
    public Text LastScore;

    void Start()
    {
        score = 0;
        updateSkor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Minus")
        {
            score -= itemValue;
        }
        else
        {
            score += itemValue;
        }
        //audio
        updateSkor();
        lastSkor();
    }

    void updateSkor()
    {
        scoreTxt.text = "" + score;
    }
    void lastSkor()
    {
        LastScore.text = "" + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    private UserProggres userProggres;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
    public RoundData getCurrentData()
    {
        return allRoundData[Random.Range(0,allRoundData.Length)];
    }

    private void LoadUserProgress()
    {
        userProggres = new UserProggres();
        if(PlayerPrefs.HasKey("Skor Tertinggi"))
        {

        }
    }
}

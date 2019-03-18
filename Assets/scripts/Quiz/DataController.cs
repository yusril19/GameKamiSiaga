using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
    public RoundData getGempa()
    {
        return allRoundData[0];
    }
    public RoundData getTsunami()
    {
        return allRoundData[1];
    }
    public RoundData getGunungBerapi()
    {
        return allRoundData[2];
    }
}

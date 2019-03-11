using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public GameObject[] items;
    private float maxWidth;
    private Renderer ren;
    public float timeleft;
    public Text timerText;
    public GameObject waktuHabisTxt;
    public GameObject restartBtn;
    public GameObject MenuButton;
    public GameObject start;
    private bool playGame;
    public BagController bag;
   

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        ren = items[0].GetComponent<Renderer>();

        playGame = false;

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targerWidth = cam.ScreenToWorldPoint(upperCorner);
        //mengambil luas item
        float itemWidth = ren.bounds.extents.x;
        //luar keseluruhan = luas screen horizontal - luas item
        maxWidth = targerWidth.x - itemWidth;

        UpdateTextTime();
    }
    //diberikan fixed update 
    void FixedUpdate()
    {
        //jika playgame true maka mulai berdetik
        if (playGame)
        {
            timeleft -= Time.deltaTime;
            if (timeleft < 0)
            {
                timeleft = 0;
            }
            UpdateTextTime();
        }
    }
    //memunculkan item 
    //spawn item dengan tingkat level mudah
    IEnumerator SpawnEasy()
    {
        playGame = true;   
        //item muncul dari atas berulang kali
        while (timeleft > 0 ) {

            yield return new WaitForSeconds(Random.Range(1.0f, 0.9f));

            GameObject item = items[Random.Range(0, items.Length)];
            Vector3 spawnPosition = new Vector3(
            Random.Range(-maxWidth, maxWidth),
            transform.position.y,
            0.0f
            );
        //item tidak berotasi
        Quaternion spawnRotation = Quaternion.identity;
        //inisiasi
        Instantiate(item, spawnPosition, spawnRotation);
            
        }
        //waktu habis tampilkan restart dan waktu habis
        yield return new WaitForSeconds(2.0f);


        waktuHabisTxt.SetActive(true);
        restartBtn.SetActive(true);
        MenuButton.SetActive(true);
    }
    IEnumerator SpawnMedium()
    {
        playGame = true;
        //item muncul dari atas berulang kali
        while (timeleft > 0)
        {

            yield return new WaitForSeconds(Random.Range(0.9f, 0.7f));

            GameObject item = items[Random.Range(0, items.Length)];
            Vector3 spawnPosition = new Vector3(
            Random.Range(-maxWidth, maxWidth),
            transform.position.y,
            0.0f
            );
            //item tidak berotasi
            Quaternion spawnRotation = Quaternion.identity;
            //inisiasi
            Instantiate(item, spawnPosition, spawnRotation);

        }
        //waktu habis tampilkan restart dan waktu habis
        yield return new WaitForSeconds(2.0f);

        waktuHabisTxt.SetActive(true);
        restartBtn.SetActive(true);
        MenuButton.SetActive(true);
    }
    IEnumerator SpawnHard()
    {
        playGame = true;
        //item muncul dari atas berulang kali
        while (timeleft > 0)
        {

            yield return new WaitForSeconds(Random.Range(0.7f, 0.5f));

            GameObject item = items[Random.Range(0, items.Length)];
            Vector3 spawnPosition = new Vector3(
            Random.Range(-maxWidth, maxWidth),
            transform.position.y,
            0.0f
            );
            //item tidak berotasi
            Quaternion spawnRotation = Quaternion.identity;
            //inisiasi
            Instantiate(item, spawnPosition, spawnRotation);

        }
        //waktu habis tampilkan restart dan waktu habis
        yield return new WaitForSeconds(2.0f);

        waktuHabisTxt.SetActive(true);
        restartBtn.SetActive(true);
        MenuButton.SetActive(true);
    }
    public void StartGameEasy()
    {
        start.SetActive(false);
        bag.turnOnControl(true);
        StartCoroutine(SpawnEasy());
    }
    public void StartGameMedium()
    {
        start.SetActive(false);
        bag.turnOnControl(true);
        StartCoroutine(SpawnMedium());
    }
    public void StartGameHard()
    {
        start.SetActive(false);
        bag.turnOnControl(true);
        StartCoroutine(SpawnHard());
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void UpdateTextTime()
    {
        timerText.text = "" + Mathf.RoundToInt(timeleft);
    }
}

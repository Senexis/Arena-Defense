using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{
    private int currentWave = 1;

    private GameObject[] spawners;
    private int playerCount;

    public int baseNumber = 5;
    public Text waveText;
    public Text remainingEnemies;

    //Wave countdown variables; might need seperation
    private Canvas nextWavePanel;
    private Canvas gameOverPanel;
    public Text waveCount;
    public Text countdown;
    public Text deadcountdown;
    public Text endScore;
    float countDownTime;

    //TODO: Add Score based on enemies
    //TODO: Add max based on spawner

    // Start is called before the first frame update
    void Start()
    {
        nextWavePanel = GameObject.FindGameObjectWithTag("WaveMenu").GetComponent<Canvas>();
        gameOverPanel = GameObject.FindGameObjectWithTag("DeadMenu").GetComponent<Canvas>();
        nextWavePanel.enabled = false;
        gameOverPanel.enabled = false;
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Current wave: " + currentWave;
        remainingEnemies.text = "Enemies remaining: " + (GameObject.FindGameObjectsWithTag("enemy").Length +
            GameObject.FindGameObjectsWithTag("FrenziedEnemy").Length);
        
        if(GameObject.FindGameObjectsWithTag("enemy").Length <= 0 && GameObject.FindGameObjectsWithTag("FrenziedEnemy").Length <= 0)
        {
            currentWave++;
            NextWave();
        }

        else if (GameObject.FindGameObjectsWithTag("Player").Length <= 0 && Time.timeScale == 1)
        {
            DeadScene();
        }   
    }

    void DeadScene()
    {
        Time.timeScale = 0;
        endScore.text = "Score: " + GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>().GetScore();

        StartCoroutine(Reset());
    }

    void NextWave()
    {
        if (currentWave != 1)
        {
            Time.timeScale = 0;
            StartCoroutine(Countdown());
        }

        int totalEnemies = baseNumber * currentWave * playerCount;
        int enemiesPerSpawner = totalEnemies / spawners.Length;
        //Divide enemynumber by spawners
        foreach (GameObject item in spawners)
        {
            item.GetComponent<SpawnController>().Spawn(enemiesPerSpawner);
        }
    }

    IEnumerator Countdown()
    {
        nextWavePanel.enabled = true;
        waveCount.text = "Wave " + currentWave + " incoming";

        for (int i = 5; i > 0; i--)
        {
            countdown.text = "" + i;
            yield return new WaitForSecondsRealtime(1);
        }

        nextWavePanel.enabled = false;
        Time.timeScale = 1;
    }

    IEnumerator Reset()
    {
        gameOverPanel.enabled = true;

        for (int i = 5; i > 0; i--)
        {
            deadcountdown.text = "" + i;
            yield return new WaitForSecondsRealtime(1);
        }

        gameOverPanel.enabled = false;
        Time.timeScale = 1;

        UnityEngine.SceneManagement.SceneManager.LoadScene(0, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}

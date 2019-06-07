using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int score;
    public Text scoreText;
    public Text restartText;
    public Text gameoverText;
    private bool gameover;
    private bool restart;

    void Start()
    {
        gameover = false;
        restart = false;
        restartText.text = "";
        gameoverText.text = "";

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        
    }
    private void Update()
    {
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameover)
            {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void GameOver()
    {
        gameoverText.text = "Game Over";
        gameover = true;

    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}

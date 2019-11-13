using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public var
    //all for controlling the spawn of hazards
    [Header("Wave Setting")]
    public GameObject hazard;   // what is spawning
    public Vector2 spawnValue;  // how many spawning
    public int hazardCount;     // How many hazards per wave
    public float startWait;     // How Long until first wave
    public float spawnWait;     // How Long until each spawn
    public float waveWait;      // How long between each wave
    [Header("Wave Setting")]
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    //private var
    private int score = 0;
    private bool gameOver, restart;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = restart = false; // set to false?
        StartCoroutine(SpawnWaves());
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R)) // Listen for R to be pushed old
            {
                //OLD WAY
                //Application.LoadLevel("Game");

                //Another way
                //SceneManager.LoadScene("Game");

                //Best way
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }

    // Create a coroutine function
    IEnumerator SpawnWaves()
    {
        // Delayed the first wave by a period of time
        yield return new WaitForSeconds(startWait); // Wait for startWait seconds

        while (true) // Now the game Starts
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y,spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            hazardCount++;
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.gameObject.SetActive(true);
                restart = true;

                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue; // Adds score to the score
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        gameOver = true;
    }
}

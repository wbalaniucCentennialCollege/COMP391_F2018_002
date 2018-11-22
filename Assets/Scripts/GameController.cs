using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NEW USING STATEMENTS
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This is where our game logic will be run
public class GameController : MonoBehaviour {
    
    [Header("Wave Settings")]
    public GameObject hazard;   // What are we spawning?
    public Vector2 spawn;       // Where do we spawn our hazards?
    public int hazardCount;     // How many hazards per wave?
    public float startWait;     // How long until the first wave?
    public float spawnWait;     // How long betwen each hazard in each wave?
    public float waveWait;      // How long between each waves?

    [Header("UI Settings")]
    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private int score;
    private bool gameOver;
    private bool restart;

	// Use this for initialization
	void Start () {
        score = 0;
        StartCoroutine(SpawnWaves());
        gameOver = false;
        restart = false;
        UpdateScore();
	}
	
    void Update()
    {
        // Check whether you are restarting
        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                // Restart our game
                // THE OLD WAY. DON'T USE THIS.
                // Application.LoadLevel("Level1");
                // THE NEW WAY. USE THIS!
                // SceneManager.LoadScene("Level1");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // Function dedicated to spawning waves of hazards
    // Coroutine
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); // Pause. This will "wait" for "startWait" seconds
        while(true)
        {
            // Spawning our hazards
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawn.x, Random.Range(-spawn.y, spawn.y));
                //                                    11                     -4         4
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            // Restart logic here
            if(gameOver)
            {
                // Active the Restart UI text
                restartText.enabled = true;
                // (Optional) Set Restart UI text
                // restartText.text = "YOUR SUPER SECRET CUSTOM MESSAGE HERE";
                // Set restart boolean value to true
                restart = true;

                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue; // score = score + newScoreValue
        // Debug.Log("Score: " + score);
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        // What happens when my game is over?
        gameOver = true;

        gameOverText.enabled = true;
    }
}

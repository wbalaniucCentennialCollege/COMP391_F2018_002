﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NEW USING STATEMENTS
using UnityEngine.UI;

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
}

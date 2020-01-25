using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloppyAvianGameLoop : MonoBehaviour
{
    [SerializeField]
    private bool gameRunning;
    [SerializeField]
    private PlayerBird playerBird;
    [Space]
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private GameObject textOverlay;

    private float lastSpawn;


    // Start is called before the first frame update
    void Start()
    {
        gameRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameRunning)
        {
            SpawnObstacle();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddForceToBird();
            }
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            GameStart();
        }
    }

    internal void GameEnd()
    {
        textOverlay.SetActive(true);
        gameRunning = false;
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(go);
        }
    }

    private void AddForceToBird() => playerBird.AddForce();

    private void GameStart()
    {
        textOverlay.SetActive(false);
        gameRunning = true;
        playerBird.Reset();
    }


    /// <summary>
    /// spawns an obstacle if the time is right
    /// </summary>
    private void SpawnObstacle()
    {
        // if enough time has passed
        if(Time.time - lastSpawn > spawnInterval)
        {
            // spawn the obstacle game object
            GameObject obstacle = Instantiate(obstaclePrefab);
            // set "now" as the last time an obstacle was spawned
            lastSpawn = Time.time;
        }
    }
}

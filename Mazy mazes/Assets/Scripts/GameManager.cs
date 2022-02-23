using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public MazeSpawner mazeSpawner;

    [SerializeField]
    private int startMazeSize = 10;
    private int mazeSize;

    [SerializeField]
    private int startFakeWallChance = 5;
    private int fakeWallChance;

    [SerializeField]
    private int startTimeLimit = 30;
    private int timeLimit;

    private float timer;
    public int timerToDisplay;
    private bool playTimer;

    public int level = 1;

    // Make instance (Singleton) in Awake
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Initialize varibles in start and generate first maze
    void Start()
    {
        mazeSize = startMazeSize;
        mazeSpawner.Rows = mazeSize;
        mazeSpawner.Columns = mazeSize;

        fakeWallChance = startFakeWallChance;
        mazeSpawner.fakeWallChance = fakeWallChance;

        timeLimit = startTimeLimit;
        LevelStart();

        mazeSpawner.GenerateNewMaze();
    }

    private void FixedUpdate()
    {
        if (playTimer)
        {
            timer -= Time.deltaTime;
            timerToDisplay = (int)timer;
            if (timerToDisplay <= 0)
            {
                GameOver();
            }
        }
    }

    public void NextLevel()
    {
        // Increment mazeSize
        // Increment fakeWallChance
        // -Increment timeLimit
        level++;
        mazeSpawner.GenerateNewMaze();
        LevelStart();
    }

    private void LevelStart()
    {
        timer = timeLimit + 1;
        timerToDisplay = timeLimit;
        playTimer = true;
    }

    private void GameOver()
    {
        playTimer = false;
        Debug.Log("Game Over");
    }
}

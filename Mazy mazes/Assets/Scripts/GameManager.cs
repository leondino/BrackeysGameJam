using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public MazeSpawner mazeSpawner;
    public PlayerControler player;
    public GameUIHandler gameUI;

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

    public int level;

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
        Restart();
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
        level++;
        Debug.Log(level % 2);
        // Increment fakeWallChance every even number level
        if (level % 2 == 0 && fakeWallChance < 100)
            fakeWallChance += 2;
        // Increment mazeSize every odd number level
        else
            mazeSize += 1;
        // Increment timeLimit every 5 levels
        if (level % 5 == 0)
            timeLimit += 10;

        // Update mazespawner with new values
        mazeSpawner.Rows = mazeSize;
        mazeSpawner.Columns = mazeSize;
        mazeSpawner.fakeWallChance = fakeWallChance;

        mazeSpawner.GenerateNewMaze();
        LevelStart();
    }

    private void LevelStart()
    {
        gameUI.UpdateLevelDisplay();
        timer = timeLimit + 1;
        timerToDisplay = timeLimit;
        playTimer = true;
    }

    private void GameOver()
    {
        playTimer = false;
        Debug.Log("Game Over");
        Restart();
    }

    private void Restart()
    {
        player.transform.position = new Vector3(0, 1, 0);
        player.GetComponent<VisionAbility>().ResetVisionAbility();

        level = 1;

        mazeSize = startMazeSize;
        mazeSpawner.Rows = mazeSize;
        mazeSpawner.Columns = mazeSize;

        fakeWallChance = startFakeWallChance;
        mazeSpawner.fakeWallChance = fakeWallChance;

        timeLimit = startTimeLimit;
        LevelStart();

        mazeSpawner.GenerateNewMaze();
    }
}

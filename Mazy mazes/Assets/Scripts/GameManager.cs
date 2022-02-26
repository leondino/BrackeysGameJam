using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public MazeSpawner mazeSpawner;
    public PlayerControler player;
    public GameUIHandler gameUI;
    public AudioManager audioManager;
    public GameObject pauseMenu, gameOverMenu;

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
    private bool lastSecondsActive;

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
            if (timerToDisplay == 5 &! lastSecondsActive)
            {
                lastSecondsActive = true;
                audioManager.SwitchBackgroundPitch(true);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void NextLevel()
    {
        level++;
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

    private void PauseGame()
    {
        audioManager.SwitchBackgroundVolume(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        audioManager.SwitchBackgroundVolume(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void GameOver()
    {
        audioManager.SwitchBackgroundVolume(true);

        Time.timeScale = 0;
        playTimer = false;
        gameOverMenu.SetActive(true);
        gameOverMenu.GetComponent<GameOverHandler>().UpdateScores();
    }

    public void Restart()
    {
        gameOverMenu.SetActive(false);
        ResumeGame();

        player.transform.position = new Vector3(0, 1, 0);
        player.GetComponent<VisionAbility>().ResetVisionAbility();

        level = 1;

        lastSecondsActive = false;
        audioManager.SwitchBackgroundPitch(false);
        audioManager.SwitchBackgroundVolume(false);

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

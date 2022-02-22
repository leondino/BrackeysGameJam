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

        mazeSpawner.GenerateNewMaze();
    }

    public void NextLevel()
    {
        // Increment mazeSize
        // Increment fakeWallChance
        level++;
        mazeSpawner.GenerateNewMaze();
    }
}

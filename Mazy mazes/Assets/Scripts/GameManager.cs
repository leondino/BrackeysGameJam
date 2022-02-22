using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MazeSpawner mazeSpawner;

    [SerializeField]
    private int startMazeSize = 10;
    private int mazeSize;

    [SerializeField]
    private int startFakeWallChance = 5;
    private int fakeWallChance;

    private int level = 1;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NextLevel()
    {

    }
}

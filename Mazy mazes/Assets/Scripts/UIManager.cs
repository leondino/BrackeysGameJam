using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startScreen, tutorialScreen;

    public void SwitchScreen()
    {
        startScreen.SetActive(!startScreen.activeSelf);
        tutorialScreen.SetActive(!tutorialScreen.activeSelf);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

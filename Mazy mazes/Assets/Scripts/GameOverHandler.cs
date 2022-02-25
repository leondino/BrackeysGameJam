using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    public TMP_Text score, highScore;
    private int previousHighscore, currentScore;

    public void UpdateScores()
    {
        previousHighscore = PlayerPrefs.GetInt("highscore");
        currentScore = GameManager.instance.level - 1;
        if (previousHighscore < currentScore)
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            previousHighscore = currentScore;
        }
        score.text = "Completed Level " + currentScore.ToString();
        highScore.text = "Highscore level " + previousHighscore;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text levelTimer, levelNumber;

    // Update is called once per frame
    void FixedUpdate()
    {
        levelTimer.text = GameManager.instance.timerToDisplay.ToString();
        levelNumber.text = "Level " + GameManager.instance.level.ToString();
    }
}

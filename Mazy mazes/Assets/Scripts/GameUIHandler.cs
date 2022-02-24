using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text levelTimer, levelNumber;
    [SerializeField]
    private Button visionButton;

    [SerializeField]
    private Sprite[] visionButtonSprites; 

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTimerDisplay();
    }

    public void UpdateLevelDisplay()
    {
        levelNumber.text = "Level " + GameManager.instance.level.ToString();
    }

    public void UpdateVisionButton(int stage)
    {
        visionButton.image.sprite = visionButtonSprites[stage];
        if (stage == 3)
            visionButton.interactable = true;
        else 
            visionButton.interactable = false;
    }

    private void UpdateTimerDisplay()
    {
        levelTimer.text = GameManager.instance.timerToDisplay.ToString();
    }
}

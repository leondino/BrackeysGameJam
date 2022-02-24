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
        if (stage < 4)
        {
            visionButton.image.sprite = visionButtonSprites[stage];
            visionButton.GetComponentInChildren<TMP_Text>().enabled = false;
        }
        else
        {
            visionButton.GetComponentInChildren<TMP_Text>().enabled = true;
        }
        if (stage == 3)
        {
            visionButton.interactable = true;
        }
        else
        {
            visionButton.interactable = false;
        }
    }

    private void UpdateTimerDisplay()
    {
        levelTimer.text = GameManager.instance.timerToDisplay.ToString();

        if (visionButton.GetComponentInChildren<TMP_Text>().enabled)
        {
            visionButton.GetComponentInChildren<TMP_Text>().text =
                GameManager.instance.player.GetComponent<VisionAbility>().
                timerToDisplay.ToString(); ;
        }
    }
}

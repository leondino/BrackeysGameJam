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

    private int myDisplayTimer;
    private float defaultFontSize;

    private void Awake()
    {
        defaultFontSize = levelTimer.fontSize;
    }

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

    public void UpdateTimerDisplay()
    {
        // Update normal timer plus enlarge effect
        if (myDisplayTimer != GameManager.instance.timerToDisplay)
        {
            myDisplayTimer = GameManager.instance.timerToDisplay;
            levelTimer.text = myDisplayTimer.ToString();
            StartCoroutine(EnlargeTimer());
        }

        // Update vision ability timer
        if (visionButton.GetComponentInChildren<TMP_Text>().enabled)
        {
            visionButton.GetComponentInChildren<TMP_Text>().text =
                GameManager.instance.player.GetComponent<VisionAbility>().
                timerToDisplay.ToString(); ;
        }
    }

    private IEnumerator EnlargeTimer()
    {
        levelTimer.fontSize = defaultFontSize * 1.15f;

        yield return new WaitForSeconds(0.25f);

        levelTimer.fontSize = defaultFontSize;
    }
}

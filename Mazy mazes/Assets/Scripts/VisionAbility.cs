using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAbility : MonoBehaviour
{
    private int visionTokens = 0;

    [SerializeField]
    private Material normalWallMat, fakeWallMat;

    [SerializeField]
    private int visionDuration;
    private float timer;
    public int timerToDisplay;
    private bool playTimer;

    private void Update()
    {
        // Test cheat code
        if (Input.GetKeyDown(KeyCode.PageUp) && visionTokens < 3)
            PickUpToken();
    }

    private void FixedUpdate()
    {
        if (playTimer)
        {
            timer -= Time.deltaTime;
            timerToDisplay = (int)timer;
            if (timerToDisplay <= 0)
            {
                ResetVisionAbility();
            }
        }
    }

    public void ActivateVisionAbility()
    {
        foreach (GameObject fakeWall in GameManager.instance.mazeSpawner.allFakeWalls)
        {
            fakeWall.GetComponent<MeshRenderer>().material = fakeWallMat;
            fakeWall.transform.GetChild(0).gameObject.
                GetComponent<MeshRenderer>().material = fakeWallMat;
        }

        GameManager.instance.gameUI.UpdateVisionButton(visionTokens + 1);
        timer = visionDuration + 1;
        playTimer = true;
    }

    public void ResetVisionAbility()
    {
        playTimer = false;
        visionTokens = 0;
        GameManager.instance.gameUI.UpdateVisionButton(visionTokens);

        foreach (GameObject fakeWall in GameManager.instance.mazeSpawner.allFakeWalls)
        {
            fakeWall.GetComponent<MeshRenderer>().material = normalWallMat;
            fakeWall.transform.GetChild(0).gameObject.
                GetComponent<MeshRenderer>().material = normalWallMat;
        }
    }

    private void PickUpToken()
    {
        visionTokens++;
        GameManager.instance.gameUI.UpdateVisionButton(visionTokens);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Token") && visionTokens < 3)
        {
            Destroy(other.gameObject);
            PickUpToken();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionAbility : MonoBehaviour
{
    private int visionTokens = 0;

    [SerializeField]
    private Material normalWallMat, fakeWallMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateVisionAbility()
    {
        foreach (GameObject fakeWall in GameManager.instance.mazeSpawner.allFakeWalls)
        {
            fakeWall.GetComponent<MeshRenderer>().material = fakeWallMat;
            fakeWall.transform.GetChild(0).gameObject.
                GetComponent<MeshRenderer>().material = fakeWallMat;
        }
    }

    public void ResetVisionAbility()
    {
        visionTokens = 0;
        GameManager.instance.gameUI.UpdateVisionButton(visionTokens);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Token") && visionTokens < 3)
        {
            visionTokens++;
            Destroy(other.gameObject);
            GameManager.instance.gameUI.UpdateVisionButton(visionTokens);
        }
    }
}

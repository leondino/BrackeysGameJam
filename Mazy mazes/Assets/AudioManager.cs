using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource clickSound, gameBackground, tokenPickup, activateVisionAbility;

    public void PlayClickSound()
    {
        clickSound.Play();
    }

    public void PlayTokenPickup()
    {
        tokenPickup.Play();
    }

    public void PlayActivateVision()
    {
        activateVisionAbility.Play();
    }
}

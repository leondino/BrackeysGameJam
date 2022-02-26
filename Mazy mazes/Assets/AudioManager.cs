using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource clickSound, gameBackgroundStart, gameBackgroundLoop, tokenPickup, activateVisionAbility;

    private void FixedUpdate()
    {
        if (gameBackgroundStart.enabled)
        {
            if (!gameBackgroundStart.isPlaying && !gameBackgroundLoop.isPlaying)
            {
                gameBackgroundLoop.Play();
            }
        }
    }

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

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

    public void SwitchBackgroundPitch(bool lastSeconds)
    {
        if (lastSeconds)
        {
            gameBackgroundLoop.pitch = 1.25f;
        }
        else
        {
            gameBackgroundLoop.pitch = 1;
        }
    }

    public void SwitchBackgroundVolume(bool gameOver)
    {
        if (gameOver)
        {
            SwitchBackgroundPitch(false);
            gameBackgroundLoop.volume = 0.2f;
        }
        else
            gameBackgroundLoop.volume = 0.5f;
    }
}

using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource shootAS;
    public AudioSource hitAS;
    public AudioSource wallHitAS;
    public AudioSource coinCollectedAS;
    public AudioSource serumCollectedAS;
    public AudioSource zombieAttackAS;
    public AudioSource ambientSound;

    public bool isSoundOff;

    public void PlayShootSFX()
    {
        if (isSoundOff) return;
        shootAS.Play();
    }
    public void PlayHitSFX()
    {
        if (isSoundOff) return;
        hitAS.Play();
    }
    public void PlayWallHitSFX()
    {
        if (isSoundOff) return;
        wallHitAS.Play();
    }
    public void PlayCoinCollectedSFX()
    {
        if (isSoundOff) return;

        coinCollectedAS.Play();
    }
    public void PlaySerumCollectedSFX()
    {
        if (isSoundOff) return;

        serumCollectedAS.Play();
    }
    public void PlayZombieAttackSFX()
    {
        if (isSoundOff) return;

        zombieAttackAS.Play();
    }

    public void StopAmbientSound()
    {
        ambientSound.Stop();
    }
    public void PlayAmbientSound()
    {
        ambientSound.Play();
    }
}

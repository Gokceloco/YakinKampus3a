using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource shootAS;
    public AudioSource hitAS;
    public AudioSource wallHitAS;
    public AudioSource coinCollectedAS;
    public AudioSource serumCollectedAS;
    public AudioSource zombieAttackAS;

    public void PlayShootSFX()
    {
        shootAS.Play();
    }
    public void PlayHitSFX()
    {
        hitAS.Play();
    }
    public void PlayWallHitSFX()
    {
        wallHitAS.Play();
    }
    public void PlayCoinCollectedSFX()
    {
        coinCollectedAS.Play();
    }
    public void PlaySerumCollectedSFX()
    {
        serumCollectedAS.Play();
    }
    public void PlayZombieAttackSFX()
    {
        zombieAttackAS.Play();
    }
}

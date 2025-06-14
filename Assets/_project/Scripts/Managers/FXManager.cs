using UnityEngine;

public class FXManager : MonoBehaviour
{
    public ParticleSystem bulletImpactPSPrefab;
    public ParticleSystem coinCollectedPSPrefab;
    public ParticleSystem serumCollectedPSPrefab;

    public void PlayBulletImpactFX(Vector3 pos, Vector3 dir, Color color)
    {
        var newPS = Instantiate(bulletImpactPSPrefab);
        newPS.transform.position = pos;
        newPS.transform.LookAt(pos - dir);
        var main = newPS.main;
        main.startColor = color;
        newPS.Play();
    }

    public void PlayCoinCollectedFX(Vector3 pos)
    {
        var newPS = Instantiate(coinCollectedPSPrefab);
        newPS.transform.position = pos;
        newPS.Play();
    }
    public void PlaySerumCollectedFX(Vector3 pos)
    {
        var newPS = Instantiate(serumCollectedPSPrefab);
        newPS.transform.position = pos;
        newPS.Play();
    }
}

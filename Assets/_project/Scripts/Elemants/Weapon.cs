using DG.Tweening;
using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public CameraHolder cameraHolder;

    public Bullet bulletPrefab;
    public Transform shootPoint;

    public ParticleSystem muzzlePS;

    public float attackRate;
    private float _lastShootTime;

    public Light muzzleLight;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time - _lastShootTime > attackRate)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = shootPoint.position;
        newBullet.transform.LookAt(newBullet.transform.position + shootPoint.forward);
        _lastShootTime = Time.time;
        GameDirector.instance.audioManager.PlayShootSFX();
        muzzlePS.Play();
        muzzleLight.DOKill();
        muzzleLight.intensity = 0;
        muzzleLight.DOIntensity(100, .05f).SetLoops(2, LoopType.Yoyo);
        cameraHolder.ShakeCamera(.2f,.2f);
    }
}

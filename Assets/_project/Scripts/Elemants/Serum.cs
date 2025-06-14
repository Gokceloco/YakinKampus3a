using DG.Tweening;
using System;
using UnityEngine;

public class Serum : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveY(transform.position.y + 1, .5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuad);

        transform.localScale = Vector3.zero;
        transform.DOScale(1, .5f).SetEase(Ease.OutBack);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collected();
        }
    }

    private void Collected()
    {
        GameDirector.instance.LevelCompleted();
        GameDirector.instance.fXManager.PlaySerumCollectedFX(transform.position + Vector3.up * 1.5f);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}

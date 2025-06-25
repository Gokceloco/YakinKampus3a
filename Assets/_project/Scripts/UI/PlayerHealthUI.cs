using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image fillBar;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(1, .2f).SetUpdate(true);
    }

    public void Hide()
    {
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(0, .2f).OnComplete(()=>gameObject.SetActive(false)).SetUpdate(true);
    }

    public void UpdateHealth(float ratio)
    {
        fillBar.DOKill();
        fillBar.DOFillAmount(ratio, .2f);
        fillBar.color = Color.red;
        fillBar.DOColor(Color.white, .1f).SetLoops(2, LoopType.Yoyo);
    }
}

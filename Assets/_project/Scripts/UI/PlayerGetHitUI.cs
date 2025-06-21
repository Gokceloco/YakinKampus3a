using DG.Tweening;
using UnityEngine;

public class PlayerGetHitUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.DOKill();
        _canvasGroup.alpha = 0;
        _canvasGroup.DOFade(1, .1f).SetLoops(2, LoopType.Yoyo);
    }
}

using DG.Tweening;
using UnityEngine;

public class VictoryUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Show(float delay)
    {
        gameObject.SetActive(true);
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(1, .2f).SetDelay(delay);
        GameDirector.instance.gameState = GameState.VictoryUI;
    }

    public void Hide()
    {
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(0, .2f).OnComplete(() => gameObject.SetActive(false));
    }

    public void LoadNextLevelButtonPressed()
    {
        Hide();
        GameDirector.instance.LoadNextLevel();
    }
}

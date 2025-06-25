using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioManager audioManager;
    private CanvasGroup _canvasGroup;

    public Button resumeButton;
    public Button startButton;

    public TextMeshProUGUI startButtonTMP;

    public Image soundOnImage;
    public Image soundOffImage;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void Show(bool showResumeButton)
    {
        gameObject.SetActive(true);
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(1, .2f).SetUpdate(true);
        if (showResumeButton)
        {
            resumeButton.interactable = true;
            //startButton.interactable = false;
            startButtonTMP.text = "RESTART LEVEL";
        }
        else
        {
            resumeButton.interactable = false;
            //startButton.interactable = true;
            startButtonTMP.text = "START GAME";
        }
    }

    public void Hide()
    {
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(0, .2f).OnComplete(() => gameObject.SetActive(false));
    }
    public void StartGameButtonPressed()
    {
        Hide();
        Time.timeScale = 1;
        GameDirector.instance.StartButtonPressed();
    }
    public void ExitButtonPressed()
    {
        Application.Quit();
    }
    public void ResumeButtonPressed()
    {
        Hide();
        Time.timeScale = 1;
        GameDirector.instance.gameState = GameState.GamePlay;
        GameDirector.instance.ShowInGameUI();
    }

    public void SoundButtonPressed()
    {
        audioManager.isSoundOff = !audioManager.isSoundOff;
        if (audioManager.isSoundOff)
        {
            soundOnImage.gameObject.SetActive(true);
            soundOffImage.gameObject.SetActive(false);
            audioManager.StopAmbientSound();
        }
        else
        {
            soundOnImage.gameObject.SetActive(false);
            soundOffImage.gameObject.SetActive(true);
            audioManager.PlayAmbientSound();
        }
    }
}

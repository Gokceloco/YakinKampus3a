using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerUI : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public List<VideoClip> videos;

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
        _canvasGroup.DOFade(0, .2f).OnComplete(() => gameObject.SetActive(false)).SetUpdate(true);
    }

    public void PlayVideoClip(int i)
    {
        Show();
        videoPlayer.clip = videos[i];
        videoPlayer.Play();
        Invoke(nameof(Hide), 5);
    }
}

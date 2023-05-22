using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteUI : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] CanvasGroup group;

    private void Start()
    {
        GameEvents.instance.onLevelFinish += Open;
        GameEvents.instance.OnLoad += Close;
    }
    private void OnDestroy()
    {
        GameEvents.instance.onLevelFinish -= Open;
        GameEvents.instance.OnLoad -= Close;
    }
    private void Open()
    {
        StartCoroutine(Wait());
    }
    private void Close()
    {
        winScreen.SetActive(false);
        group.alpha = 0;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        winScreen.SetActive(true);
        float myFloat = 0;
        DOTween.To(() => myFloat, x => myFloat = x, 1, 0.5f).SetEase(Ease.Linear).OnUpdate(() => group.alpha = myFloat);
    }
}

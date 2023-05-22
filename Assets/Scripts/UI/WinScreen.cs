using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] CanvasGroup group;

    private void Start()
    {
        GameEvents.instance.onWin += Open;
        GameEvents.instance.OnLoad += Close;
        GameEvents.instance.close += Close;
        GameEvents.instance.contGameReally += Close;

    }
    private void OnDestroy()
    {
        GameEvents.instance.onWin -= Open;
        GameEvents.instance.OnLoad -= Close;
        GameEvents.instance.close -= Close;
        GameEvents.instance.contGameReally -= Close;

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

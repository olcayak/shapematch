using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FailScreen : MonoBehaviour
{
    [SerializeField] GameObject failScreen;
    [SerializeField] CanvasGroup group;

    private void Start()
    {
        GameEvents.instance.onFail += Open;
        GameEvents.instance.onRestart += Close;

    }
    private void OnDestroy()
    {
        GameEvents.instance.onFail -= Open;
        GameEvents.instance.onRestart -= Close;

    }
    private void Open()
    {

        transform.DOMove(transform.position, 2).OnComplete(() => StartCoroutine(Wait()));


    }
    private void Close()
    {
        failScreen.SetActive(false);
        group.alpha = 0;
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(1.5f);

        failScreen.SetActive(true);
        float myFloat = 0;
        DOTween.To(() => myFloat, x => myFloat = x, 1, 0.5f).SetEase(Ease.Linear).OnUpdate(() => group.alpha = myFloat);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateAll : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float rotateSpeed;
    public bool canRotate = true;
    [SerializeField] public string rotateInt;
    private void Awake()
    {
        Check();
    }

    private void Check()
    {
        if (PlayerPrefsX.GetBool(rotateInt, false))
        {
            canRotate = false;
        }
    }
    private void OnDestroy()
    {
        DOTween.Kill(this);
    }
    public void Win()
    {
        transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f).SetEase(Ease.InSine).SetTarget(this);
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.OutSine).SetDelay(0.35f).SetTarget(this);
        canRotate = false;
        PlayerPrefsX.SetBool(rotateInt, true);
    }   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OpenFridge : MonoBehaviour
{
    [SerializeField] Transform fridgeDoor;
    [SerializeField] int whicAc;
    void Start()
    {
        GameEvents.instance.activite += Open;
        GameEvents.instance.contGame += Close;
    }
    private void OnDestroy()
    {
        GameEvents.instance.activite -= Open;
        GameEvents.instance.contGame -= Close;
    }
    private void Open(int i)
    {
        if(i == whicAc)
        {
            fridgeDoor.DOLocalRotate(new Vector3(0, 110, -180), 1.5f).SetDelay(0.8f).SetEase(Ease.OutBack);
        }
    }
    private void Close()
    {
        fridgeDoor.DOLocalRotate(new Vector3(0, 0, -180), 1.5f).SetEase(Ease.InBack);
    }
}

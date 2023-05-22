using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EndArrow : MonoBehaviour
{
    [SerializeField] Transform arrow;
    private void Start()
    {
        Rotate();
    }
   
    private void Rotate()
    {
        Sequence sequence = DOTween.Sequence();
        var o =arrow.DORotate(new Vector3(0, 0, 73), 1).SetEase(Ease.Linear);
        var s = arrow.DORotate(new Vector3(0, 0, -73), 1).SetEase(Ease.Linear);
        sequence.Append(o);
        sequence.Append(s);
        sequence.SetLoops(-1, LoopType.Restart);
    }
}

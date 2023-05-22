using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlackScreen : MonoBehaviour
{
    [SerializeField] Image blackSc;
    void Start()
    {
        GameEvents.instance.BlackScreen += Come;
    }
    private void OnDestroy()
    {
        GameEvents.instance.BlackScreen -= Come;
    }
    private void Come()
    {
        blackSc.DOFade(1, 0.2f);
        blackSc.DOFade(0, 0.5f).SetDelay(0.5f);
    }
}

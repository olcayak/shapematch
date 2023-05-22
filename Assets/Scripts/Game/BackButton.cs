using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject backButton;
    FixGameControl fixgame;
    private void Start()
    {
        GameEvents.instance.openBack += OpenAndSet;
        GameEvents.instance.onWin += Close;

    }
    private void OnDestroy()
    {
        GameEvents.instance.openBack -= OpenAndSet;
        GameEvents.instance.onWin -= Close;
    }
    private void OpenAndSet(FixGameControl fix)
    {
        if (!PlayerPrefsX.GetBool("isFirst1", true))
        {
            backButton.SetActive(true);
        }
        fixgame = fix;
    }
    private void Close()
    {
        backButton.SetActive(false);
    }
    public void CloseAndSet()
    {
        VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.MediumImpact);

        DOTween.KillAll();
        GameEvents.instance.cameraTrig.Invoke(-1);
        foreach (var item in fixgame.allRotate)
        {
            item.enabled = false;
        }
        for (int i = 0; i < fixgame.fixObjects.Count; i++)
        {
            fixgame.fixObjects[i].transform.DOMove(fixgame.objectFixedPos[i].position, 0.2f);
            fixgame.fixObjects[i].transform.DORotate(fixgame.objectFixedPos[i].eulerAngles, 0.2f);
            fixgame.fixObjects[i].transform.DOScale(Vector3.one, 0.2f);

        }
        GameEvents.instance.closeBack?.Invoke();
        backButton.SetActive(false);

    }
}

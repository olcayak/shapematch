using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SettingsButton : MonoBehaviour
{
    [SerializeField] GameObject[] sound;
    [SerializeField] GameObject[] vibrate;
    [SerializeField] Transform dropDown;

    public void DropDown()
    {
        if (!DOTween.IsTweening(this))
        {
            if (dropDown.localScale.y == 0)
            {
                dropDown.DOScaleY(1, 0.3f).SetEase(Ease.OutBack).SetTarget(this);
            }
            else
            {
                dropDown.DOScaleY(0, 0.3f).SetEase(Ease.InBack).SetTarget(this);
            }
        }

    }
    public void Vibrate()
    {
        if (DataHandler.instance.isVibrate)
        {
            foreach (var vibrates in vibrate)
            {
                vibrates.SetActive(false);
            }
            vibrate[0].SetActive(true);
            DataHandler.instance.isVibrate = false;
        }
        else
        {
            foreach (var vibrates in vibrate)
            {
                vibrates.SetActive(false);
            }
            vibrate[1].SetActive(true);
            DataHandler.instance.isVibrate = true;
        }
    }
    public void Sound()
    {
        if (AudioListener.volume == 1)
        {
            foreach (var sounds in sound)
            {
                sounds.SetActive(false);
            }
            sound[0].SetActive(true);
            AudioListener.volume = 0;
        }
        else
        {
            foreach (var sounds in sound)
            {
                sounds.SetActive(false);
            }
            sound[1].SetActive(true);
            AudioListener.volume = 1;
        }
    }
}

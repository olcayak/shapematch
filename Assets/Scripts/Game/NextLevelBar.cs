using Dreamteck.Splines.Primitives;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelBar : MonoBehaviour
{
    [SerializeField] GameObject barGO;
    [SerializeField] Image barImage;
    [SerializeField] int howManyeAct;
    [SerializeField] int whichLevel;
    private void Start()
    {
        SetBarImage();
        GameEvents.instance.activite += Close;
        GameEvents.instance.contGame += SetBarImage;
        GameEvents.instance.close += SetBarImage;
        GameEvents.instance.closeBack += SetBarImage;

    }
    private void OnDestroy()
    {
        GameEvents.instance.activite -= Close;
        GameEvents.instance.contGame -= SetBarImage;
        GameEvents.instance.close -= SetBarImage;
        GameEvents.instance.closeBack -= SetBarImage;

    }

    private void Close(int i)
    {
        barGO.SetActive(false);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        barGO.SetActive(true);
        var str = "level" + whichLevel.ToString();

        float x = (float)PlayerPrefs.GetInt(str, 0) / (float)howManyeAct;

        barImage.fillAmount = x;
    }
    private void SetBarImage()
    {
        StartCoroutine(Wait());
    }
}

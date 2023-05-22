using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] GameObject upgrades;
    [SerializeField] GameObject multiply;
    [SerializeField] GameObject firstNext;

    private void Start()
    {
        Check();
        GameEvents.instance.OnLoad += Check;
    }
    private void OnDestroy()
    {
        GameEvents.instance.OnLoad -= Check;

    }
    private void Check()
    {
        if (PlayerPrefsX.GetBool("isFirst1", false))
        {
            upgrades.SetActive(true);
            multiply.SetActive(true);
            firstNext.SetActive(false);
        }
        else
        {
            multiply.SetActive(false);
            firstNext.SetActive(true);
        }

    }
}

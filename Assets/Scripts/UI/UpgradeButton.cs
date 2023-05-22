using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public int level
    {
        get { return PlayerPrefs.GetInt("level" + nameT, 1); }
        set { PlayerPrefs.SetInt("level" + nameT, value); }
    }
    public int upgradeLevel
    {
        get { return PlayerPrefs.GetInt("upgradeLevel" + nameT, 0); }
        set { PlayerPrefs.SetInt("upgradeLevel" + nameT, value); }
    }


    [SerializeField] Sprite[] sprites;

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] string nameT;

    [SerializeField] int[] howMuchMoney;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image imageUI;
    private void Start()
    {
        nameText.text = nameT;
        SetBg(1);
        SetMoneyTexts();
        GameEvents.instance.OnMoneyChange += SetBg;

    }
    private void OnDestroy()
    {
        GameEvents.instance.OnMoneyChange -= SetBg;
    }
    private void SetBg(int i)
    {
        if (upgradeLevel == howMuchMoney.Length)
        {
            imageUI.sprite = sprites[2];

        }
        else
        if (howMuchMoney[upgradeLevel] > DataHandler.instance.money)
        {
            imageUI.sprite = sprites[1];
        }
        else
        {
            imageUI.sprite = sprites[0];
        }

    }
    private void SetMoneyTexts()
    {
        if (upgradeLevel == howMuchMoney.Length)
        {
            moneyText.text = "MAX";
            levelText.text = "Level " + (upgradeLevel + 1).ToString();
        }
        else
        {
            moneyText.text = howMuchMoney[upgradeLevel].ToString();
            levelText.text = "Level " + (upgradeLevel + 1).ToString();
        }
    }

    public void Upgrade()
    {
        if (upgradeLevel == howMuchMoney.Length)
        {
            if (howMuchMoney[upgradeLevel] <= DataHandler.instance.money)
            {
                DataHandler.instance.Lowermoney(howMuchMoney[upgradeLevel]);
                level += 1;
                upgradeLevel += 1;
                VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.LightImpact);
                SetMoneyTexts();
                SetBg(1);
                GameEvents.instance.upgrade?.Invoke();
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneytext;

    private void Start()
    {
        Set(DataHandler.instance.money);
        GameEvents.instance.OnMoneyChange += Set;
    }
    private void Set(int i)
    {
        moneytext.text = i.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndGameMoneyWin : MonoBehaviour
{
    [SerializeField] int money;

    [SerializeField] int which = 1;
    [SerializeField] Text moneyText;
    [SerializeField] TextMeshProUGUI winText;

    private void Start()
    {
        WinMoney();
        GameEvents.instance.onWin += WinMoney;
    }
    private void OnDestroy()
    {
        GameEvents.instance.onWin += WinMoney;
    }


    private void WinMoney()
    {
        winText.text = (money * (DataHandler.instance.level + 1)).ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        which = int.Parse(collision.name);
        moneyText.text = ((int)money * which * (DataHandler.instance.level + 1)).ToString();
    }

    public void GetMoney()
    {
        DataHandler.instance.Increasemoney(((int)money) * which * (DataHandler.instance.level + 1));
    }
}

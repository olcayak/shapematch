using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoSingleton<DataHandler>
{
    public int money
    {
        get { return PlayerPrefs.GetInt("money", 0); }
        set {  PlayerPrefs.SetInt("money", value); }
    }

    public int level
    {
        get { return PlayerPrefs.GetInt("level", 0); }
        set {  PlayerPrefs.SetInt("level", value); }
    }
    public bool isVibrate
    {
        get { return PlayerPrefsX.GetBool("isVibrate", true); }
        set { PlayerPrefsX.SetBool("isVibrate", value); }

    }

    public void Increaselevel()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 0) + 1);
    }
    public void Increasemoney(int i)
    {
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) + i);
        GameEvents.instance.OnMoneyChange?.Invoke(money);

    }
    public void Lowermoney(int i)
    {
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) - i);
        GameEvents.instance.OnMoneyChange?.Invoke(money);
    }
    public void SetMoney(int i)
    {
        PlayerPrefs.SetInt("money", i);
        GameEvents.instance.OnMoneyChange?.Invoke(money);
    }
}

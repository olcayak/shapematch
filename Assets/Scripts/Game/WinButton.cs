using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinButton : MonoBehaviour
{
    public void ContGame()
    {
        GameEvents.instance.contGame?.Invoke();
    }
}

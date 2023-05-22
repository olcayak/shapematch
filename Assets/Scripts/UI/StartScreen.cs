using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    [SerializeField] GameObject startScreen;

    private void Start()
    {
        GameEvents.instance.onGameStart += Close;
        GameEvents.instance.OnLoad += Open;

    }
    private void OnDestroy()
    {
        GameEvents.instance.onGameStart -= Close;
        GameEvents.instance.OnLoad -= Open;
    }
    private void Close()
    {
        startScreen.SetActive(false);
    }
    private void Open()
    {
        startScreen.SetActive(true);
    }
}

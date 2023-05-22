using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;

    private void Start()
    {
        GameEvents.instance.OnLoadEnd += Close;
    }
    private void OnDestroy()
    {
        GameEvents.instance.OnLoadEnd -= Close;
    }
    private void Close()
    {
        loadingScreen.SetActive(false);
    }
}

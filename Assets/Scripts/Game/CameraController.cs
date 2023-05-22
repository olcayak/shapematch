using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    [SerializeField] List<CinemachineVirtualCamera> camers;
    void Start()
    {
        GameEvents.instance.cameraTrig += Change;
        GameEvents.instance.contGameReally += GirlCam;
    }

    private void OnDestroy()
    {
        GameEvents.instance.cameraTrig -= Change;
        GameEvents.instance.contGameReally -= GirlCam;
    }
    private void GirlCam()
    {
        GameEvents.instance.BlackScreen?.Invoke();
        StartCoroutine(Wait2());

    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (var item in camers)
        {
            item.enabled = false;
        }
        camers[0].enabled = true;
    }
    private void Change(int i)
    {
        GameEvents.instance.BlackScreen?.Invoke();

        StartCoroutine(Wait(i));
    }
    IEnumerator Wait(int i)
    {
        yield return new WaitForSeconds(0.2f);
        foreach (var item in camers)
        {
            item.enabled = false;
        }
        camers[i + 1].enabled = true;
    }
}

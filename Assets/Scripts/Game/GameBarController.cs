using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBarController : MonoBehaviour
{
    [SerializeField] GameObject barGO;
    [SerializeField] List<GameObject> stars;
    private void Start()
    {
        GameEvents.instance.openGameBar += Open;
        GameEvents.instance.openStar += Right;
        GameEvents.instance.contGame += Close;
        GameEvents.instance.closeBack += Close;

    }
    private void OnDestroy()
    {
        GameEvents.instance.openGameBar -= Open;
        GameEvents.instance.openStar -= Right;
        GameEvents.instance.contGame -= Close;
        GameEvents.instance.closeBack -= Close;
    }
    private void Close()
    {
        barGO.SetActive(false);
    }
    private void Right(int which)
    {
        stars[which].transform.GetChild(0).gameObject.SetActive(true);
    }
    IEnumerator WaitOpen(int j, int a)
    {
        yield return new WaitForSeconds(0.2f);
        barGO.SetActive(true);
        foreach (var item in stars)
        {
            item.SetActive(false);
        }
        foreach (var item in stars)
        {
            item.transform.GetChild(0).gameObject.SetActive(false);
        }
        for (int i = 0; i < j; i++)
        {
            stars[i].SetActive(true);
        }
        for (int i = 0; i < a; i++)
        {
            stars[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void Open(int j, int a)
    {
        StartCoroutine(WaitOpen(j, a));
    }
}

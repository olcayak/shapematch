using Dreamteck.Splines.Primitives;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    [SerializeField] int howManyAct;
    [SerializeField] int whichLevel;
    private void Start()
    {
        Check();
        GameEvents.instance.contGame += Check;
    }
    private void OnDestroy()
    {
        GameEvents.instance.contGame -= Check;
    }
    private void Check()
    {
        StartCoroutine(Wait1());
    }
    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.1f);
        var str = "level" + whichLevel.ToString();

        
        if (PlayerPrefs.GetInt(str, 0) == howManyAct)
        {
            GameEvents.instance.cameraTrig.Invoke(-1);
            GameEvents.instance.close?.Invoke();

            StartCoroutine(Wait());
        }
        else
        {
            GameEvents.instance.contGameReally?.Invoke();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.8f);

        GameEvents.instance.confett?.Invoke();
        yield return new WaitForSeconds(0.2f);
        GameEvents.instance.onLevelFinish?.Invoke();

    }
}

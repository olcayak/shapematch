using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayButton : MonoBehaviour
{
    int whichAct;
    [SerializeField]public int level;
    [SerializeField] FixGameControl game;
    [SerializeField] SpriteRenderer sprite;
    bool spamCheck = true;
    private void Start()
    {
        whichAct = game.whichAc;
        GameEvents.instance.contGame += Check;
        GameEvents.instance.closeBack += Check;

        Check();
    }
    private void OnDestroy()
    {
        GameEvents.instance.contGame -= Check;
        GameEvents.instance.closeBack -= Check;
    }
    private void Check()
    {
        var str = "act" + whichAct.ToString() + "level" + level.ToString();

        if (PlayerPrefsX.GetBool(str , false))
        {
            if (this.enabled)
            {
                StartCoroutine(WaitClose());
            }
        }
        else
        {
            spamCheck = true;

            gameObject.SetActive(true);
            this.enabled = true;
        }
    }
    IEnumerator WaitClose()
    {
        yield return new WaitForSeconds(0.2f);

        gameObject.SetActive(false);
        this.enabled = false;
    }
    private void OnMouseDown()
    {
        if (spamCheck)
        {
            VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.MediumImpact);
            spamCheck = false;
            StartCoroutine(WaitSpam());
            gameObject.SetActive(false);
            this.enabled = false;
            GameEvents.instance.activite?.Invoke(whichAct);
        }
    
    }
    IEnumerator WaitSpam()
    {
        yield return new WaitForSeconds(1);
        spamCheck = true;
    }
    public string Name()
    {
        var str = "act" + whichAct.ToString() + "level" + level.ToString();
        return str;
    }
    public void Finish()
    {
        var str = "act" + whichAct.ToString() + "level" + level.ToString();
        PlayerPrefsX.SetBool(str, true);
         str = "level" + level.ToString();

        PlayerPrefs.SetInt(str, PlayerPrefs.GetInt(str, 0) + 1);
    }
 
}

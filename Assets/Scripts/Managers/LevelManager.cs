using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] LevelAsset[] levelAsset;
    bool spamCheck = true;
    [SerializeField] bool isWork;
    private void Start()
    {
        DOTween.SetTweensCapacity(500, 50);
      
        if (!isWork)
            StartCoroutine(LoadFirst(DataHandler.instance.level % levelAsset.Length));
    }
    public void Restart()
    {
        if (spamCheck)
        {
            VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.LightImpact);

            spamCheck = false;
            GameEvents.instance.onRestart?.Invoke();
            var level = DataHandler.instance.level % levelAsset.Length;
           
            StartCoroutine(Load(level, SceneManager.GetSceneAt(1).name));
        }

    }
    public void NextLevel()
    {
        if (spamCheck)
        {


            VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.LightImpact);
            DataHandler.instance.Increaselevel();
            spamCheck = false;
            var level = DataHandler.instance.level % levelAsset.Length;
          
            StartCoroutine(Load(level, SceneManager.GetSceneAt(1).name));
            var money = DataHandler.instance.money;
            var levelll = DataHandler.instance.level;
            var vibr = DataHandler.instance.isVibrate;
            PlayerPrefs.DeleteAll();
            DataHandler.instance.money = money;
            DataHandler.instance.level = levelll;
            DataHandler.instance.isVibrate = vibr;
            PlayerPrefsX.SetBool("isFirst1", false);
        }

    }
    IEnumerator Load(int whereScene, string unlodName)
    {
        GameEvents.instance.OnLoad?.Invoke();
        GameManager.instance.gameState = GameStates.Wait;

        var asyncUnload = SceneManager.UnloadSceneAsync(unlodName);
        yield return new WaitUntil(() => asyncUnload.isDone);

        var name = levelAsset[whereScene].name;
        var asyncLoad = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        yield return new WaitUntil(() => asyncLoad.isDone);
        spamCheck = true;
        yield return new WaitForSeconds(0.2f);
        GameManager.instance.gameState = GameStates.Start;

        GameEvents.instance.OnLoadEnd?.Invoke();

    }
    IEnumerator LoadFirst(int whereScene)
    {
        GameEvents.instance.OnLoad?.Invoke();
        yield return new WaitForSeconds(0.2f);

        var name = levelAsset[whereScene].name;
        var asyncLoad = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        yield return new WaitUntil(() => asyncLoad.isDone);

        yield return new WaitForSeconds(1f);
        GameEvents.instance.OnLoadEnd?.Invoke();

    }
}

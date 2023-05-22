using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoSingleton<GameEvents>
{
    public UnityAction onGameStart;
    public UnityAction onFail;
    public UnityAction onRestart;
    public UnityAction onWin;
    public UnityAction onLevelFinish;
    public UnityAction close;
    public UnityAction confett;
    public UnityAction OnLoad;
    public UnityAction OnLoadEnd;
    public UnityAction<int> OnMoneyChange;
    public UnityAction<int> activite;
    public UnityAction<int> cameraTrig;
    public UnityAction upgrade;
    public UnityAction<FixGameControl> openBack;
    public UnityAction closeBack;

    public UnityAction contGame;
    public UnityAction<int> openStar;
    public UnityAction contGameReally;
    public UnityAction<int, int> openGameBar;
    public UnityAction<RotateObject> rightPos;


    public UnityAction<GameObject, GameObject> Merge;


    public UnityAction BlackScreen;
    public UnityAction WhiteScreen;
}

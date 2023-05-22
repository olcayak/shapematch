using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public GameStates gameState = GameStates.Start;

    public void GameStart()
    {
        if (gameState == GameStates.Start)
        {
            GameEvents.instance.onGameStart?.Invoke();
            StartCoroutine(Wait());
        }
    }
    public void GameWin()
    {
        gameState = GameStates.Win;
        GameEvents.instance.onWin?.Invoke();

    }
    public void GameFail()
    {
        gameState = GameStates.Lose;

        GameEvents.instance.onFail?.Invoke();

    }
    public void WaitState()
    {
        gameState = GameStates.Wait;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        gameState = GameStates.GamePlay;

    }
}

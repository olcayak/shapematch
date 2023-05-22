using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines.Primitives;

public class FixGameControl : MonoBehaviour
{
    [System.Serializable]
    struct Rotate
    {
        public List<RotateObject> obj;
    }
    [SerializeField] List<Rotate> rotatebles;
    [SerializeField] PlayButton button;
    [SerializeField] public List<RotateAll> allRotate;
    int howManyObj;

    public List<GameObject> fixObjects = new List<GameObject>();
     List<int> howManyPieces = new List<int>();
    [SerializeField]  List<Transform> objectFixingPos;
    [SerializeField] public List<Transform> objectFixedPos;
    [SerializeField] public int whichAc;
    int whichObj;
    int whichObjPiece;
    private void Start()
    {
        GameEvents.instance.activite += StartGame;
        GameEvents.instance.rightPos += CountWin;
        GameEvents.instance.closeBack += BackGame;
        foreach (var item in allRotate)
        {
            fixObjects.Add(item.gameObject);
        }
        foreach (var item in rotatebles)
        {
            howManyPieces.Add(item.obj.Count);
        }
        howManyObj = fixObjects.Count;
    }
    private void OnDestroy()
    {
        GameEvents.instance.activite -= StartGame;
        GameEvents.instance.rightPos -= CountWin;
        GameEvents.instance.closeBack -= BackGame;

    }
    private void BackGame()
    {
        StopAllCoroutines();
    }
    private void StartGame(int i)
    {
        if (i == whichAc)
        {
            GameEvents.instance.openBack?.Invoke(this);

            int ho = 0;
            foreach (var item in allRotate)
            {
                if (!item.canRotate)
                {
                    ho++;
                }
            }
            whichObj = ho;
            GameEvents.instance.openGameBar?.Invoke(howManyObj,ho);
            GameEvents.instance.cameraTrig.Invoke(whichAc);
            StartCoroutine(Wait());

        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.8f);

        for (int i = whichObj; i < fixObjects.Count; i++)
        {
            fixObjects[i].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f).SetEase(Ease.InSine);
            fixObjects[i].transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.OutSine).SetDelay(0.35f);
        }
       

        yield return new WaitForSeconds(1);
        fixObjects[whichObj].transform.DOMove(objectFixingPos[whichObj].position, 1).SetEase(Ease.InOutSine);
        fixObjects[whichObj].transform.DORotate(objectFixingPos[whichObj].eulerAngles, 1, RotateMode.FastBeyond360).SetEase(Ease.InOutSine).OnComplete(() => allRotate[whichObj].enabled = true);
        foreach (var obj in rotatebles[whichObj].obj)
        {
            obj.enabled = true;
        }
        foreach (var item in allRotate)
        {
            item.enabled = false;
        }
    }
    private void CountWin(RotateObject obj)
    {
        if (rotatebles.Count > whichObj)
        {
            if (rotatebles[whichObj].obj.Contains(obj))
            {
                whichObjPiece++;
                if (whichObjPiece == howManyPieces[whichObj])
                {
                    foreach (var item in allRotate)
                    {
                        item.enabled = false;
                    }
                    foreach (var can in rotatebles[whichObj].obj)
                    {
                        can.enabled = false;
                    }
                    whichObj++;
                    if (whichObj == howManyObj)
                    {
                        GameManager.instance.GameWin();
                        fixObjects[whichObj - 1].transform.DOMove(objectFixedPos[whichObj - 1].position, 1).SetEase(Ease.InOutSine).SetDelay(0.7f);
                        fixObjects[whichObj - 1].transform.DORotate(objectFixedPos[whichObj - 1].eulerAngles, 1, RotateMode.FastBeyond360).SetEase(Ease.InOutSine).SetDelay(0.7f).OnComplete(() => GameEvents.instance.confett?.Invoke());
                        allRotate[whichObj - 1].Win();
                        GameEvents.instance.openStar?.Invoke(whichObj - 1);
                        button.Finish();

                    }
                    else
                    {
                        fixObjects[whichObj - 1].transform.DOMove(objectFixedPos[whichObj - 1].position, 1).SetEase(Ease.InOutSine).SetDelay(0.7f);
                        fixObjects[whichObj - 1].transform.DORotate(objectFixedPos[whichObj - 1].eulerAngles, 1, RotateMode.FastBeyond360).SetEase(Ease.InOutSine).SetDelay(0.7f);
                        allRotate[whichObj - 1].Win();
                        GameEvents.instance.openStar?.Invoke(whichObj - 1);

                        ContGame();
                    }
                }
            }
        }
      

    }
    private void ContGame()
    {
        StartCoroutine(Wait2());
    }
    IEnumerator Wait2()
    {
        whichObjPiece = 0;
        yield return new WaitForSeconds(2.5f);
        fixObjects[whichObj].transform.DOMove(objectFixingPos[whichObj].position, 1).SetEase(Ease.InOutSine);
        fixObjects[whichObj].transform.DORotate(objectFixingPos[whichObj].eulerAngles, 1, RotateMode.FastBeyond360).SetEase(Ease.InOutSine).OnComplete(() => allRotate[whichObj].enabled = true);
        foreach (var obj in rotatebles[whichObj].obj)
        {
            obj.enabled = true;
        }

    }
}

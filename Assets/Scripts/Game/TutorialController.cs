using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] List<GameObject> hands;
    [SerializeField] GameObject text;
    int whichHand;

    private void Start()
    {
        if (PlayerPrefsX.GetBool("isFirst1", true))
        {
            GameEvents.instance.rightPos += NextHand;

            Tutorial();
        }
    }
    private void OnDestroy()
    {
        if (PlayerPrefsX.GetBool("isFirst1", true))
        {
            GameEvents.instance.rightPos -= NextHand;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        GameEvents.instance.activite?.Invoke(5);
        yield return new WaitForSeconds(3);
        text.SetActive(true);
        hands[whichHand].SetActive(true);
    }
    private void NextHand(RotateObject obj)
    {
        foreach (var item in hands)
        {
            item.SetActive(false);
        }
        whichHand++;
        if (whichHand == hands.Count)
        {
            PlayerPrefsX.SetBool("isFirst1", false);
            text.SetActive(false);
            GameEvents.instance.rightPos -= NextHand;

        }
        else
        {

            hands[whichHand].SetActive(true);

        }

    }
    private void Tutorial()
    {
        StartCoroutine(Wait());
    }
}

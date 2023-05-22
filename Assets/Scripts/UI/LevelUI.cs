using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;

    private void Start()
    {
        Set();
        GameEvents.instance.OnLoad += Set;
    }
    private void Set()
    {
        levelText.text = "Level " + (DataHandler.instance.level + 1).ToString();
    }
}

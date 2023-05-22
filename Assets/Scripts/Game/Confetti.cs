using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    [SerializeField] ParticleSystem confet;

    private void Start()
    {
        GameEvents.instance.confett += Play;
    }
    private void OnDestroy()
    {
        GameEvents.instance.confett -= Play;
    }
    private void Play()
    {
        confet.Play();
    }
}

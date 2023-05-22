using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExpo : MonoBehaviour
{
    [SerializeField] ParticleSystem stars;

   
    public void Expo(RotateObject obj)
    {
        stars.transform.position = obj.transform.position;

        stars.Play();
    }
}

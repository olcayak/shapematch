using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Dreamteck.Splines.Primitives;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 5;
    [SerializeField] bool isX;
    public MeshRenderer mesh { get; set; }
    Transform par;
    StarExpo star;
    [SerializeField] int reverse = 1;
    bool isPlaced;
    private void Start()
    {
        CheckFinished();
#if UNITY_EDITOR
        rotateSpeed *= 10;
#endif
        par = transform.parent.parent;
        mesh = GetComponent<MeshRenderer>();
        gameObject.tag = "Rotatable";
        gameObject.AddComponent<MeshCollider>();
        star = par.GetComponent<StarExpo>();
        
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        var par = transform.parent.parent.parent;
        var but = par.Find("play").GetComponent<PlayButton>();
        var str = but.Name();
        if (PlayerPrefsX.GetBool(str, false))
        {
            transform.DOLocalRotate(Vector3.zero, 0);
        }

        var rot = transform.parent.parent.GetComponent<RotateAll>();
        if (PlayerPrefsX.GetBool(rot.rotateInt, false))
        {
            transform.DOLocalRotate(Vector3.zero, 0);
        }
        this.enabled = false;
    }
    private void CheckFinished()
    {
        StartCoroutine(Wait());
    }
    private void OnMouseDown()
    {
        if (!isPlaced)
        {
            mesh.material.SetFloat("_RimSize", 1);
            VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.Selection);
        }

    }
    private void OnMouseDrag()
    {
        if (!isPlaced)
        {
            if (isX)
            {
                float x = Input.GetAxis("Mouse X") * rotateSpeed;

                transform.Rotate(Vector3.down, x * reverse);

            }
            else
            {
                float y = Input.GetAxis("Mouse Y") * rotateSpeed;
                transform.Rotate(Vector3.right, -y * reverse);

            }
        }
    }
    private void OnMouseUp()
    {

        if (!isPlaced)
        {
            mesh.material.SetFloat("_RimSize", 5);

            if (!isX)
            {
                var x = Mathf.Abs(transform.localRotation.x);


                if (x < 0.1)
                {
                    VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.Success);
                    star.Expo(this);

                    GameEvents.instance.rightPos?.Invoke(this);
                    isPlaced = true;
                    transform.DOLocalRotate(Vector3.zero, 0.1f).SetEase(Ease.Linear);
                }
                else
                {
                    VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.Warning);

                }
            }
            else
            {
                var y = Mathf.Abs(transform.localRotation.y);

                if (y < 0.1)
                {
                    VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.Success);
                    star.Expo(this);
                    GameEvents.instance.rightPos?.Invoke(this);
                    isPlaced = true;
                    transform.DOLocalRotate(Vector3.zero, 0.1f).SetEase(Ease.Linear);
                }
                else
                {
                    VibrationController.instance.Vibrate(Lofelt.NiceVibrations.HapticPatterns.PresetType.Warning);

                }
            }
        }
    }
}

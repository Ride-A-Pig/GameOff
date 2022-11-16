using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MetalPipeAim : MonoBehaviour,IAimableObject
{
    public void DoInteract()
    {
        this.gameObject.AddComponent<Rigidbody>();
    }

    public void OnAimEnter()
    {
        Debug.Log("Enter");
    }

    public void OnAimExit()
    {

        Debug.Log("Exit");
    }

    public void OnAimStay()
    {
        Debug.Log("Stay");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Camera.main.transform.DOShakePosition(1, new Vector3(0.03f, 0.03f, 0));
            PlayerController.instance.pass();
            AimSystem.Instance.canOpr = false;
        }
    }
}

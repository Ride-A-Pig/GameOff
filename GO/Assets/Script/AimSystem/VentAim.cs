using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VentAim : MonoBehaviour, IAimableObject
{
    public Vector3 force;
    public void DoInteract()
    {
        //this.transform.rotation = Quaternion.Euler(90, 0, 1.483f);
        //this.transform.position = new Vector3(0.105f, -0.03f, -0.058f);
        Rigidbody rigi;
        rigi=this.gameObject.AddComponent<Rigidbody>();
        rigi.drag = 0;
        rigi.AddForce(force);
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
            Camera.main.transform.DOShakePosition(1, new Vector3(0.01f, 0.01f, 0));
        }
    }
}

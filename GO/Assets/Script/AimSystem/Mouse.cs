using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mouse : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer==7)
        {
            Camera.main.transform.DOShakePosition(1, new Vector3(0.005f, 0.005f, 0));
            PlayerController.instance.flee();
        }
    }

}

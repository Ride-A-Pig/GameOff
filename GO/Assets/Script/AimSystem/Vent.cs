using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Vent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Camera.main.transform.DOShakePosition(1, new Vector3(0.02f, 0.02f, 0));
        }
    }
}

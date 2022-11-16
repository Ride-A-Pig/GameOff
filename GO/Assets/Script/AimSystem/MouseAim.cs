using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseAim : MonoBehaviour,IAimableObject
{
    public void DoInteract()
    {
        AimSystem.Instance.canOpr = false;
        GameObject mouse = Resources.Load("Rat") as GameObject;
        GameObject.Instantiate(mouse,this.transform);
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

}

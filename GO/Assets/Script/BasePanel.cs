using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel 
{
    public UIType uIType;
    public GameObject activeObj;

    public BasePanel(UIType _uIType)
    {
        uIType = _uIType;
    }
    public virtual void onStart()
    {
        UIMethod.AddOrGetComponent<CanvasGroup>(activeObj).interactable = true;
    }
    public virtual void onEnable()
    {
        UIMethod.AddOrGetComponent<CanvasGroup>(activeObj).interactable = true;
    }

    public virtual void onDisable()
    {
        UIMethod.AddOrGetComponent<CanvasGroup>(activeObj).interactable = false;
    }
    public virtual void onDestory()
    {
        UIMethod.AddOrGetComponent<CanvasGroup>(activeObj).interactable = false;

    }
}

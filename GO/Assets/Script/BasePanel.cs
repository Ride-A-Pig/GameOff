using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel 
{
    /// <summary>
    /// 储存uiPanel的名字和加载路径信息
    /// </summary>
    public UIType uIType;
    /// <summary>
    /// 当前ui在场景中绑定的物体
    /// </summary>
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

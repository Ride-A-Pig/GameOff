using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using System;

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

    public State curState;

    public Image image;
    public  CanvasGroup cg;

    public Sprite[] sprites;
    public Sprite originImage;

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
    #region play
    public async void fali(Sprite[] sprites, float durationTime)
    {
        onDestory();

        foreach (var item in sprites)
        {

            cg.DOFade(0, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));

            image.sprite = item;

            cg.DOFade(1, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));
        }

        onStart();
        restart(durationTime);
        //image.sprite = originImage;
    }
    public async void restart(float durationTime)
    {
        onDestory();
        cg.DOFade(0, durationTime);
        await Task.Delay(TimeSpan.FromSeconds(durationTime));

        image.sprite = originImage;

        cg.DOFade(1, durationTime);
        await Task.Delay(TimeSpan.FromSeconds(durationTime));
        curState = null;
        onStart();
    }
    public async void pass(Sprite[] sprites, float durationTime)
    {
        onDestory();

        foreach (var item in sprites)
        {

            cg.DOFade(0, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));

            image.sprite = item;

            cg.DOFade(1, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));
        }

        onStart();
        //image.sprite = originImage;
    }
    #endregion
}

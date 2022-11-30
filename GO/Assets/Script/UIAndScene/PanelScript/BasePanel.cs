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
    public bool isPlaying=false;

    public BasePanel(UIType _uIType)
    {
        uIType = _uIType;
    }
    public virtual void onStart()
    {
        UIMethod.AddOrGetComponent<CanvasGroup>(activeObj).interactable = true;
        AudioMgr.Instance.playChangeClip();
        GameManager.getInstance().script_StartUI.clear(true);
    }
    public virtual void onEnable()
    {
        UIMethod.AddOrGetComponent<CanvasGroup>(activeObj).interactable = true;
        AudioMgr.Instance.playChangeClip();
        GameManager.getInstance().script_StartUI.clear(true);
    }

    public virtual void onDisable()
    {
        UIMethod.AddOrGetComponent<CanvasGroup>(activeObj).interactable = false;
        AudioMgr.Instance.stop();
        GameManager.getInstance().script_StartUI.clear(false);
    }
    public virtual void onDestory()
    {
        UIMethod.AddOrGetComponent<CanvasGroup>(activeObj).interactable = false;

        AudioMgr.Instance.stop();
        GameManager.getInstance().script_StartUI.clear(false);
    }
    #region play
    public async void fali(Sprite[] sprites, float durationTime=1.5f)
    {
        //if (isPlaying) return;
        isPlaying = true;
        foreach (var item in sprites)
        {

            cg.alpha = 0;
            await Task.Delay(TimeSpan.FromSeconds(durationTime));

            image.sprite = item;
            AudioMgr.Instance.playChangeClip();

            cg.alpha = 1;
            await Task.Delay(TimeSpan.FromSeconds(durationTime));
        }
        RemakePanel remakePanel = new RemakePanel();
        UIManager.getInstance().push(remakePanel);
        Debug.Log(remakePanel);
        remakePanel.basePanel = this;
    }
    public virtual async void restart(float durationTime=1.5f)
    {
        
        isPlaying = true;
        cg.alpha = 0;
        await Task.Delay(TimeSpan.FromSeconds(durationTime));

        image.sprite = originImage;
        AudioMgr.Instance.playChangeClip();

        cg.alpha = 1;
        await Task.Delay(TimeSpan.FromSeconds(durationTime));

        curState = null;
        isPlaying = false;
        GameManager._instance.timer = 0;
    }
    public virtual async void pass(Sprite[] sprites, float durationTime=1.5f)
    {
        isPlaying = true;
        GameManager._instance.timer = 0;
        foreach (var item in sprites)
        {
            GameManager._instance.timer = 0;
            cg.alpha = 0;
            await Task.Delay(TimeSpan.FromSeconds(durationTime));

            image.sprite = item;
            AudioMgr.Instance.playChangeClip();

            cg.alpha = 1;
            await Task.Delay(TimeSpan.FromSeconds(durationTime));
        }
        isPlaying = false;
        GameManager._instance.timer = 0;
    }
    
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager 
{
    private Dictionary<string, GameObject> dic_ui;
    public Stack<BasePanel> sta_ui;
    /// <summary>
    /// 场景下的画布
    /// </summary>
    public GameObject canvesObj;
    private static UIManager instance;

    public static UIManager getInstance()
    {
        if(instance==null)
        {
            Debug.LogError("NotFoundInstance");
            return null;
        }
        return instance;
    }

    public UIManager()
    {
        dic_ui = new Dictionary<string, GameObject>();
        sta_ui = new Stack<BasePanel>();
        instance = this;
    }
    public GameObject getSingleObj(UIType uIType)
    {
        if(dic_ui.ContainsKey(uIType.Name))
        {
            return dic_ui[uIType.Name];
        }
        if(canvesObj==null)
        {
            canvesObj = UIMethod.getCanves();
        }
        GameObject uiObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uIType.Path), canvesObj.transform);
        dic_ui.Add(uIType.Name, uiObj);
        return uiObj;
    }
    public void push(BasePanel uiPanel)
    {
        
        if(sta_ui.Count==0)
        {
            GameObject uiObj = getSingleObj(uiPanel.uIType);
            uiPanel.activeObj = uiObj;
            uiObj.name = uiPanel.uIType.Name;
            sta_ui.Push(uiPanel);
        }
        else
        {
            if(sta_ui.Peek().uIType.Name!=uiPanel.uIType.Name)
            {
                sta_ui.Peek().onDisable();
                
                GameObject uiObj = getSingleObj(uiPanel.uIType);
                uiPanel.activeObj = uiObj;
                uiObj.name = uiPanel.uIType.Name;
                sta_ui.Push(uiPanel);
            }
        }
        
        uiPanel.onStart();
    }
    public void pop(bool isLoad)
    {

        if(isLoad)
        {
            if(sta_ui.Count>0)
            {
                dic_ui.Remove(sta_ui.Peek().uIType.Name);
                sta_ui.Peek().onDisable();
                sta_ui.Peek().onDestory();
                GameObject.DestroyImmediate(sta_ui.Peek().activeObj);
                sta_ui.Pop();
                
                pop(true);
            }
        }
        else
        {
            if (sta_ui.Count > 0)
            {

                dic_ui.Remove(sta_ui.Peek().uIType.Name);
                sta_ui.Peek().onDisable();
                sta_ui.Peek().onDestory();
                GameObject.DestroyImmediate(sta_ui.Peek().activeObj);
                sta_ui.Pop();

                if(sta_ui.Count>0)
                {
                    sta_ui.Peek().onEnable();
                }
            }
        }
        
    }
}

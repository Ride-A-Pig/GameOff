using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using System;

public class RemakePanel : BasePanel
{
    private static string _name = "RemakePanel";
    private static string _path = @"Panel\RemakePanel";
    public static UIType uiType = new UIType(_name, _path);

    public BasePanel basePanel;
    public RemakePanel() : base(uiType)
    {

    }

    public override void onStart()
    {
        base.onStart();
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Remake").onClick.AddListener(remake);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Close").onClick.AddListener(close);
    }

    public override void onEnable()
    {
        base.onEnable();
    }

    public override void onDisable()
    {
        base.onDisable();
    }

    public override void onDestory()
    {
        base.onDestory();
    }
    private void remake()
    {
        basePanel.restart();
        UIManager.getInstance().pop(false);
    }
    private void close()
    {
        UIManager.getInstance().pop(true);
    }
}

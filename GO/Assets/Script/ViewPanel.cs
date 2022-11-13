using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewPanel : BasePanel
{
    private static string _name = "ViewPanel";
    private static string _path = @"Panel\ViewPanel";
    public static UIType uiType = new UIType(_name, _path);
    public ViewPanel() : base(uiType)
    {

    }

    public override void onStart()
    {
        base.onStart();
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "CloseBtn").onClick.AddListener(close);
    }
    private void close()
    {
        UIManager.getInstance().pop(false);
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
}

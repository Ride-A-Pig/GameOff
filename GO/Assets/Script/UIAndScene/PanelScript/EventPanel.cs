using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPanel : BasePanel
{
    private static string _name = "EventPanel";
    private static string _path = @"Panel\EventPanel";
    public static UIType uiType = new UIType(_name, _path);
    public EventPanel() : base(uiType)
    {
        
    }

    public override void onDestory()
    {
        base.onDestory();
    }

    public override void onDisable()
    {
        base.onDisable();
    }

    public override void onEnable()
    {
        base.onEnable();
    }

    public override void onStart()
    {
        base.onStart();
    }

}

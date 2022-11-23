using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : BasePanel
{
    private static string _name = "StartPanel";
    private static string _path = @"Panel\StartPanel";
    public static UIType uiType = new UIType(_name, _path);
    public StartPanel() : base(uiType)
    {

    }

    public override void onStart()
    {
        base.onStart();
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "CloseDD").onClick.AddListener(closeDD);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Load").onClick.AddListener(changeScene);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Load0").onClick.AddListener(changeScene0);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "ViewBtn").onClick.AddListener(view);

    }
    private void closeDD()
    {
        GameObject.DestroyImmediate(UIMethod.findObjInChildren(activeObj, "Dropdown"));
        //UIMethod.findObjInChildren(activeObj, "Dropdown").SetActive(false);
    }
    private void changeScene()
    {
         Scene1 scene1 = new Scene1();
         SceneControl.getInstance().Load(Scene1.nameScene, scene1);
         
    }
    private void changeScene0()
    {
        Scene0 scene0 = new Scene0();
        SceneControl.getInstance().Load(Scene0.nameScene, scene0);
    }
    private void view()
    {
        UIManager.getInstance().push(new ViewPanel());
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

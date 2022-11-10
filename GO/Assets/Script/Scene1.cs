using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : SceneBase
{
    public static string nameScene = "Scene1";
    public override void enterScene()
    {
        UIManager.getInstance().push(new StartPanel());
    }

    public override void exitScene()
    {
        //Debug.Log("Scene1Exit");
        //UIManager.getInstance().pop(true);
    }
}

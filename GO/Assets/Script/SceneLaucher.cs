using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLaucher : SceneBase
{
    public static string nameScene = "Laucher";
    public override void enterScene()
    {
        UIManager.getInstance().push(new StartPanel());
        //Debug.Log($"Load{SceneManager.GetActiveScene().name}");
    }

    public override void exitScene()
    {
        //UIManager.getInstance().pop(true);
    }
}

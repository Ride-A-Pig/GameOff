using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene0 : SceneBase
{
    public static string nameScene = "Scene0";
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

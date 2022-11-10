using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl 
{
    private Dictionary<string, SceneBase> dic_scene = new Dictionary<string, SceneBase>
    {
        [Scene0.nameScene] = new Scene0(),
        [Scene1.nameScene]=new Scene1(),
        [SceneLaucher.nameScene]=new SceneLaucher()
    };

    private static SceneControl instance;
    
    public static SceneControl getInstance()
    {
        if(instance==null)
        {
            Debug.Log("NotFindSceneInstance");
        }
        return instance;
    }

    public SceneControl()
    {
        instance = this;

    }

    
    public void Load(string nameScene,SceneBase sceneBase)
    {
        if(!dic_scene.ContainsKey(nameScene))
        {
            dic_scene.Add(nameScene, sceneBase);
        }
        //Debug.Log(SceneManager.GetActiveScene().name);
        //Debug.Log(nameScene);
        dic_scene[SceneManager.GetActiveScene().name].exitScene();

        #region popAllUI
        UIManager.getInstance().pop(true);
        #endregion

        SceneManager.LoadScene(nameScene);
        sceneBase.enterScene();
    }
}

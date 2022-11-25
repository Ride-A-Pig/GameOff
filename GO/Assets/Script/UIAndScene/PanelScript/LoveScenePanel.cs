using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using System;

public class State
{
    public string name;

    public State()
    {

    }

    public State(string name)
    {
        this.name = name;
    }
}
public class LoveScenePanel : BasePanel
{
    private static string _name = "LoveScenePanel";
    private static string _path = @"Panel\LoveScenePanel";
    public static UIType uiType = new UIType(_name, _path);

    
    public Dictionary<string, State> dicState = new Dictionary<string, State>
    {
        
        { "Ball",new State("Ball")},
        { "Ring",new State("Ring")},
        { "Book",new State("Book")},
        { "Sign",new State("Sign")},

    };
    public LoveScenePanel() : base(uiType)
    {

    }
    
    public override void onStart()
    {
        base.onStart();

        image = UIMethod.AddOrGetComponentInChildren<Image>(activeObj, "Bg");
        cg = activeObj.GetComponent<CanvasGroup>();
        originImage= Resources.Load<Sprite>("BaseScene");

        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Ball").onClick.AddListener(ballClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Ring").onClick.AddListener(ringClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Book").onClick.AddListener(bookClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Sign").onClick.AddListener(signClick);

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
    
    #region ClickEvent
    public async void signClick()
    {
        if (curState == null)
        {
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点牌子");
            pass(sprites, 2);

            curState = dicState["Sign"];

            await Task.Delay(TimeSpan.FromSeconds(4.5f));
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/换箭");
            fali(sprites, 2);

        }


    }
    public void bookClick()
    {
        if (curState == null)
        {
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点课本");
            pass(sprites, 2);

            curState = dicState["Book"];

        }
        else if (curState.name == "Sign")
        {
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/换箭");
            fali(sprites, 2);
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点牌子+点课本");
            fali(sprites, 2);

            curState = dicState["Book"];
        }

    }
    public void ballClick()
    {
        if (curState == null)
        {

            curState = dicState["Ball"];

            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点球");
            pass(sprites, 2);


        }
        else if (curState.name == "Sign")
        {

            curState = dicState["Ball"];

            sprites = Resources.LoadAll<Sprite>("恋爱结局2/换箭");
            pass(sprites, 2);
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点牌子+点球");
            fali(sprites, 2);

        }

    }
    public void ringClick()
    {
        if (curState == null)
        {

            curState = dicState["Ring"];

            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点上课铃");
            fali(sprites, 2);


        }
        else if (curState.name == "Sign")
        {

            curState = dicState["Ring"];

            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点牌子+点上课铃");
            pass(sprites, 2);

        }

    }
    #endregion
}

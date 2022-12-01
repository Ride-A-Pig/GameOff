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
    
    public override async void onStart()
    {
        base.onStart();

        image = UIMethod.AddOrGetComponentInChildren<Image>(activeObj, "Bg");
        cg = activeObj.GetComponent<CanvasGroup>();
        originImage= Resources.Load<Sprite>("BaseScene");

        AudioMgr.Instance.playLoveBGM();

        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Ball").onClick.AddListener(ballClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Ring").onClick.AddListener(ringClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Book").onClick.AddListener(bookClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Sign").onClick.AddListener(signClick);

        float d = 5f;
        startScene("Dialog2", d);
        await Task.Delay(TimeSpan.FromSeconds(4*d));
        image.sprite = originImage;
    }

    public override void onEnable()
    {
        AudioMgr.Instance.playLoveBGM();
        base.onEnable();
    }

    public override void onDisable()
    {
        base.onDisable();
    }

    public override void onDestory()
    {
        base.onDestory();
        AudioMgr.Instance.playClip("SceneSwitch_1");
    }
    
    #region ClickEvent
    public async void signClick()
    {
        if (curState == null)
        {
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点牌子");
            pass(sprites);

            curState = dicState["Sign"];

            await Task.Delay(TimeSpan.FromSeconds(6.5f));
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/换箭");
            pass(sprites);

        }


    }
    public void bookClick()
    {
        if (curState == null)
        {
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点课本");
            fali(sprites);

            curState = dicState["Book"];

        }
        else if (curState.name == "Sign")
        {
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/换箭");
            fali(sprites);
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点牌子+点课本");
            fali(sprites);

            curState = dicState["Book"];
        }

    }
    public void ballClick()
    {
        if (curState == null)
        {
            curState = dicState["Ball"];

            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点球");
            fali(sprites);
        }
        else if (curState.name == "Sign")
        {

            curState = dicState["Ball"];
            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点牌子+点球");
            fali(sprites);

        }

    }
    public void ringClick()
    {
        if (curState == null)
        {

            curState = dicState["Ring"];

            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点上课铃");
            fali(sprites);


        }
        else if (curState.name == "Sign")
        {

            curState = dicState["Ring"];

            sprites = Resources.LoadAll<Sprite>("恋爱结局2/点牌子+点上课铃");
            success(sprites);
        }

    }
    public async void success(Sprite[] sprites, float durationTime=1.5f)
    {
        //if (isPlaying) return;
        isPlaying = true;
       
        foreach (var item in sprites)
        {

            cg.alpha = 0;
            AudioMgr.Instance.playChangeClip();
            await Task.Delay(TimeSpan.FromSeconds(durationTime));

            lock(image.sprite)
            {
                image.sprite = item;
            }
            

            cg.alpha = 1;
            await Task.Delay(TimeSpan.FromSeconds(durationTime));
        }
        isPlaying = false;
        //onEnable();
        GameManager._instance.timer = 0;
        GameManager.getInstance().script_StartUI.passLove();
        GameManager.getInstance().script_StartUI.RemotePage.SetActive(false);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using System;


public class HorrorScenePanel : BasePanel
{
    private static string _name = "HorrorScenePanel";
    private static string _path = @"Panel\HorrorScenePanel";
    public static UIType uiType = new UIType(_name, _path);

    public State curState;

    private static Image image;
    public static CanvasGroup cg;

    public Sprite[] sprites;
    public Sprite originImage;
    public Dictionary<string, State> dicState = new Dictionary<string, State>
    {

        { "Water_Pipe",new State("Water_Pipe")},
        { "Vent",new State("Vent")},
        { "Rat",new State("Rat")},
        { "Metal_Pipe",new State("Metal_Pipe")},
        { "Devil",new State("Devil")}

    };
    public HorrorScenePanel() : base(uiType)
    {

    }

    public override void onStart()
    {
        base.onStart();

        image = UIMethod.AddOrGetComponentInChildren<Image>(activeObj, "Bg");
        cg = activeObj.GetComponent<CanvasGroup>();
        originImage = Resources.Load<Sprite>("Horror_base_scene");

        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Devil").onClick.AddListener(devilClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Metal_Pipe").onClick.AddListener(metalPipeClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Rat").onClick.AddListener(ratClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Vent").onClick.AddListener(ventClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Water_Pipe").onClick.AddListener(waterPipeClick);

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
    #region play
    public async void playResult(Sprite[] sprites, float durationTime)
    {
        onDestory();

        foreach (var item in sprites)
        {

            cg.DOFade(0, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));

            image.sprite = item;

            cg.DOFade(1, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));
        }

        onStart();
        restart(durationTime);
        //image.sprite = originImage;
    }
    public async void restart(float durationTime)
    {
        onDestory();
        cg.DOFade(0, durationTime);
        await Task.Delay(TimeSpan.FromSeconds(durationTime));

        image.sprite = originImage;

        cg.DOFade(1, durationTime);
        await Task.Delay(TimeSpan.FromSeconds(durationTime));
        curState = null;
        onStart();
    }
    public async void pass(Sprite[] sprites, float durationTime)
    {
        onDestory();

        foreach (var item in sprites)
        {

            cg.DOFade(0, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));

            image.sprite = item;

            cg.DOFade(1, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));
        }

        onStart();
        //image.sprite = originImage;
    }
    #endregion
    #region ClickEvent
    public  void waterPipeClick()
    {
        if (curState == null)
        {
            curState = dicState["Water_Pipe"];

            sprites = Resources.LoadAll<Sprite>("HorrorLevel/Water_Pipe");
            playResult(sprites, 2);

            

        }


    }
    public void ventClick()
    {
        if (curState == null)
        {

            curState = dicState["Vent"];

            sprites = Resources.LoadAll<Sprite>("HorrorLevel/Vent");
            playResult(sprites, 2);
        }
    }

    public void ratClick()
    {
        if (curState == null)
        {
            curState = dicState["Rat"];

            sprites = Resources.LoadAll<Sprite>("HorrorLevel/Rat");
            playResult(sprites, 2);
        }
    }
    public void metalPipeClick()
    {
        if (curState == null)
        {
            curState = dicState["Metal_Pipe"];

            sprites = Resources.LoadAll<Sprite>("HorrorLevel/Metal_Pipe");
            pass(sprites, 2);
        }
    }
    public void devilClick()
    {
        if (curState == null)
        {

            curState = dicState["Devil"];
            
            sprites = Resources.LoadAll<Sprite>("HorrorLevel/Devil");
            for (int i = 0; i < sprites.Length / 2; i++)
            {
                Sprite tmp = sprites[i];
                sprites[i] = sprites[sprites.Length - i - 1];
                sprites[sprites.Length - i - 1] = tmp;
            }

            playResult(sprites, 0.2f);
        }
       

    }
    #endregion
}

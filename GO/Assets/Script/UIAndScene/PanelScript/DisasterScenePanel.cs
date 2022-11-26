using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;
using System;

public class DisasterScenePanel : BasePanel
{
    private static string _name = "DisasterScenePanel";
    private static string _path = @"Panel\DisasterScenePanel";
    public static UIType uiType = new UIType(_name, _path);


    public Dictionary<string, State> dicState = new Dictionary<string, State>
    {

        { "Door",new State("Door")},
        { "Bulb",new State("Bulb")},
        { "Protagonist",new State("Protagonist")},
        { "Plank",new State("Plank")},
        { "DoNothing",new State("DoNothing")}

    };
    public DisasterScenePanel() : base(uiType)
    {

    }

    public override void onStart()
    {
        base.onStart();

        image = UIMethod.AddOrGetComponentInChildren<Image>(activeObj, "Bg");
        cg = activeObj.GetComponent<CanvasGroup>();
        originImage = Resources.Load<Sprite>("灾难片动画/基础关卡/apocalypse_base_scene_2");

        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Plank").onClick.AddListener(plankClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Protagonist").onClick.AddListener(protagonistClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Bulb").onClick.AddListener(bulbClick);
        UIMethod.AddOrGetComponentInChildren<Button>(activeObj, "Door").onClick.AddListener(doorClick);

        restart(2);

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
    public void plankClick()
    {
        if (curState == null)
        {
            transition("Plank", "灾难片动画/点木板/Plank");
            pass(sprites, 2);

        }
        else if (curState.name == "Door")
        {
            transition("Plank", "灾难片动画/点门/点木板");
            fali(sprites, 2);
        }

    }
    public void doorClick()
    {
        if (curState == null)
        {
            transition("Door", "灾难片动画/点门/点门基础");
            pass(sprites, 2);

        }
        else if (curState.name == "Protagonist")
        {
            if(image.sprite.name == "apocalypse_woodplank+MC_1" || image.sprite.name == "apocalypse_woodplank+MC_2")
            {
                transition("Door", "灾难片动画/点木板/点主角/第一张图结束之前点击门板");
                pass(sprites, 2);
            }
        }

    }
    public void bulbClick()
    {
        if (curState == null)
        {
            transition("Bulb", "灾难片动画/点灯泡/Bulb");
            pass(sprites, 2);

        }
        else if (curState.name == "Plank")
        {
            transition("Bulb", "灾难片动画/点木板/点灯泡");
            fali(sprites, 2);
        }
        else if (curState.name == "Door")
        {
            transition("Bulb", "灾难片动画/点门/电灯泡");
            fali(sprites, 2);
        }
        else if(curState.name== "Protagonist")
        {
            Debug.Log(image.sprite.name);
            if (image.sprite.name == "apocalypse_woodplank+MC_1")
            {
                transition("Bulb", "灾难片动画/点木板/点主角/第一张结束之前点击吊灯");
                pass(sprites, 2);
            }
            else if(image.sprite.name == "apocalypse_woodplank+MC_2")
            {
                transition("Bulb", "灾难片动画/点木板/点主角/第二张图之前无作为");
                fali(sprites, 2);
            }
        }
    }
    public void protagonistClick()
    {
        if (curState == null)
        {
            transition("Protagonist", "灾难片动画/点主角");
            fali(sprites, 2);

        }
        else if(curState.name == "Bulb")
        {
            transition("Protagonist", "灾难片动画/点灯泡/点主角");
            fali(sprites, 2);
        }
        else if (curState.name == "Door")
        {
            transition("Protagonist", "灾难片动画/点门/点主角");
            fali(sprites, 2);
        }
        else if (curState.name == "Plank")
        {
            transition("Protagonist", "灾难片动画/点木板/点主角/preposition");
            pass(sprites, 2);
        }

    }
    public void doNothing()
    {
        if (curState == null)
        {
            transition("DoNothing", "灾难片动画/无作为");
            fali(sprites, 2);

        }
        else if (curState.name == "Bulb")
        {
            transition("DoNothing", "灾难片动画/点灯泡/无作为");
            fali(sprites, 2);
        }
        else if (curState.name == "Door")
        {
            transition("DoNothing", "灾难片动画/点门/无作为");
            fali(sprites, 2);
        }
        else if (curState.name == "Plank")
        {
            transition("DoNothing", "灾难片动画/点木板/无作为");
            fali(sprites, 2);
        }
        else if (curState.name == "Protagonist")
        {
            transition("DoNothing", "灾难片动画/点木板/点主角/第二张图之前无作为");
            fali(sprites, 2);
        }
    }
    protected void transition(string stateName,string path)
    {
        curState = dicState[stateName];

        sprites = Resources.LoadAll<Sprite>(path);
    }
    public override async void restart(float durationTime)
    {
        onDestory();

        isPlaying = true;

        sprites = Resources.LoadAll<Sprite>("灾难片动画/基础关卡");
        foreach (var item in sprites)
        {

            cg.DOFade(0, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));

            image.sprite = item;

            cg.DOFade(1, durationTime);
            await Task.Delay(TimeSpan.FromSeconds(durationTime));
        }
        isPlaying = false;

        curState = null;
        GameManager._instance.timer = 0;
        onEnable();
    }
}

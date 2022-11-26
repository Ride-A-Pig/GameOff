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
        originImage = Resources.Load<Sprite>("����Ƭ����/�����ؿ�/apocalypse_base_scene_2");

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
            transition("Plank", "����Ƭ����/��ľ��/Plank");
            pass(sprites, 2);

        }
        else if (curState.name == "Door")
        {
            transition("Plank", "����Ƭ����/����/��ľ��");
            fali(sprites, 2);
        }

    }
    public void doorClick()
    {
        if (curState == null)
        {
            transition("Door", "����Ƭ����/����/���Ż���");
            pass(sprites, 2);

        }
        else if (curState.name == "Protagonist")
        {
            if(image.sprite.name == "apocalypse_woodplank+MC_1" || image.sprite.name == "apocalypse_woodplank+MC_2")
            {
                transition("Door", "����Ƭ����/��ľ��/������/��һ��ͼ����֮ǰ����Ű�");
                pass(sprites, 2);
            }
        }

    }
    public void bulbClick()
    {
        if (curState == null)
        {
            transition("Bulb", "����Ƭ����/�����/Bulb");
            pass(sprites, 2);

        }
        else if (curState.name == "Plank")
        {
            transition("Bulb", "����Ƭ����/��ľ��/�����");
            fali(sprites, 2);
        }
        else if (curState.name == "Door")
        {
            transition("Bulb", "����Ƭ����/����/�����");
            fali(sprites, 2);
        }
        else if(curState.name== "Protagonist")
        {
            Debug.Log(image.sprite.name);
            if (image.sprite.name == "apocalypse_woodplank+MC_1")
            {
                transition("Bulb", "����Ƭ����/��ľ��/������/��һ�Ž���֮ǰ�������");
                pass(sprites, 2);
            }
            else if(image.sprite.name == "apocalypse_woodplank+MC_2")
            {
                transition("Bulb", "����Ƭ����/��ľ��/������/�ڶ���ͼ֮ǰ����Ϊ");
                fali(sprites, 2);
            }
        }
    }
    public void protagonistClick()
    {
        if (curState == null)
        {
            transition("Protagonist", "����Ƭ����/������");
            fali(sprites, 2);

        }
        else if(curState.name == "Bulb")
        {
            transition("Protagonist", "����Ƭ����/�����/������");
            fali(sprites, 2);
        }
        else if (curState.name == "Door")
        {
            transition("Protagonist", "����Ƭ����/����/������");
            fali(sprites, 2);
        }
        else if (curState.name == "Plank")
        {
            transition("Protagonist", "����Ƭ����/��ľ��/������/preposition");
            pass(sprites, 2);
        }

    }
    public void doNothing()
    {
        if (curState == null)
        {
            transition("DoNothing", "����Ƭ����/����Ϊ");
            fali(sprites, 2);

        }
        else if (curState.name == "Bulb")
        {
            transition("DoNothing", "����Ƭ����/�����/����Ϊ");
            fali(sprites, 2);
        }
        else if (curState.name == "Door")
        {
            transition("DoNothing", "����Ƭ����/����/����Ϊ");
            fali(sprites, 2);
        }
        else if (curState.name == "Plank")
        {
            transition("DoNothing", "����Ƭ����/��ľ��/����Ϊ");
            fali(sprites, 2);
        }
        else if (curState.name == "Protagonist")
        {
            transition("DoNothing", "����Ƭ����/��ľ��/������/�ڶ���ͼ֮ǰ����Ϊ");
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

        sprites = Resources.LoadAll<Sprite>("����Ƭ����/�����ؿ�");
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

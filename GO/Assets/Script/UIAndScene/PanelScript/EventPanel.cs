using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EventPanel : BasePanel
{
    private static string _name = "EventPanel";
    private static string _path = @"Panel\EventPanel";
    public static UIType uiType = new UIType(_name, _path);
    private static Image image;
    public static CanvasGroup cg;
    public EventPanel() : base(uiType)
    {
        
    }

    public override void onDestory()
    {
        base.onDestory();
    }

    public override void onDisable()
    {
        base.onDisable();
    }

    public override void onEnable()
    {
        base.onEnable();
    }

    public override void onStart()
    {
        base.onStart();
        image = UIMethod.AddOrGetComponentInChildren<Image>(activeObj, "Image");
        cg = activeObj.GetComponent<CanvasGroup>();
    }
    /// <summary>
    /// 播放不同的结局
    /// </summary>
    /// <param name="sprites">结局图片</param>
    /// <param name="durationTime">每张图片持续的时间</param>
    /// <returns></returns>
    public static IEnumerator playResult(Sprite[] sprites,float durationTime)
    {
        cg.alpha = 1;
        AimSystem.Instance.canOpr = false;
        foreach (var item in sprites)
        {
            image.sprite = item;
            while (image.color.a < 1)
            {
                
                image.color = new Color(255,255,255, image.color.a+0.01f);
                yield return  new WaitForSeconds(0.005f);
            }
            yield return new WaitForSeconds(durationTime);
            while (image.color.a > 0)
            {
                image.color = new Color(255, 255, 255, image.color.a - 0.01f);
                yield return new WaitForSeconds(0.005f);
            }
            yield return new WaitForSeconds(durationTime);
            
        }
        AimSystem.Instance.canOpr = true;
        cg.alpha = 0;
        image.sprite = null;
    }
    public static IEnumerator ghost(Sprite[] sprites)
    {
        AimSystem.Instance.canOpr = false;
        cg.alpha = 1;
        foreach (var item in sprites)
        {
            image.sprite = item;
            image.color = new Color(255, 255, 255, 1);
            //while (image.color.a < 1)
            //{

            //    image.color = new Color(255, 255, 255, image.color.a + 0.01f);
            //    yield return new WaitForSeconds(0.005f);
            //}
            //while (image.color.a > 0)
            //{
            //    image.color = new Color(255, 255, 255, image.color.a - 0.01f);
            //    yield return new WaitForSeconds(0.005f);
            //}
            yield return new WaitForSeconds(0.2f);
        }
        image.color = new Color(255, 255, 255, 0);
        cg.alpha = 0;
        image.sprite = null;
        AimSystem.Instance.canOpr = true;
    }
    
}

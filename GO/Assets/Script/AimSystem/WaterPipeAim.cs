using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPipeAim : MonoBehaviour,IAimableObject
{
    private Sprite[] sprites;

    public void DoInteract()
    {
        sprites = Resources.LoadAll<Sprite>("Water_Pipe");
        StartCoroutine(EventPanel.playResult(sprites, 2f));
    }

    public void OnAimEnter()
    {
        
    }

    public void OnAimExit()
    {
        
    }

    public void OnAimStay()
    {
        
    }

}

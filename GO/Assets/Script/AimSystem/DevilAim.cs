using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilAim : MonoBehaviour,IAimableObject
{
    private Sprite[] sprites;

    public void DoInteract()
    {
        print("Devil");
        
        
        sprites = Resources.LoadAll<Sprite>("Devil");
        for (int i = 0; i < sprites.Length / 2; i++)
        {
            Sprite tmp = sprites[i];
            sprites[i] = sprites[sprites.Length - i - 1];
            sprites[sprites.Length - i - 1] = tmp;
        }

        StartCoroutine(EventPanel.ghost(sprites));
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

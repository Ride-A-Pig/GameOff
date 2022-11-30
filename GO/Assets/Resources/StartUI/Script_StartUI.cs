using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Script_StartUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI TimeDisplay;
    [SerializeField] GameObject TurnOffPanel;
    [SerializeField] GameObject BrowserPage;
    [SerializeField] GameObject EmailPage;
    [SerializeField] public GameObject RemotePage;
    [SerializeField] AudioSource SFX;
    [SerializeField] public Button[] Level_Buttons;
    [SerializeField] public bool[] Level_Active = { true, false, false };
    [SerializeField] public GameObject[] Emails;
    [SerializeField] public bool[] Email_Active = { true, true, false, false, false };
    [SerializeField] GameObject[] gameObjects = new GameObject[4];

    bool bTurnOffPanel = false;
    void Start()
    {
        findObj();

        for (int i = 0; i < Emails.Length; i++)
        {
            Emails[i].SetActive(Email_Active[i]);
        }
        for(int i = 0; i < Level_Buttons.Length; i++)
        {
            Level_Buttons[i].interactable = Level_Active[i];
        }

        RemotePage.SetActive(false);
        TurnOffPanel.SetActive(false);
        BrowserPage.SetActive(false);
        EmailPage.SetActive(false);
    }

    void Update()
    {
        TimeDisplay.text = System.DateTime.Now.ToString();
    }

    public void On_TurnOffButton_Clicked()
    {
        TurnOffPanel.SetActive(!bTurnOffPanel);
        bTurnOffPanel = !bTurnOffPanel;
        Play_SFX_Clicked();
    }

    public void On_TurnOffPanelYes_Clicked()
    {
        Application.Quit();
    }

    public void On_TurnOffPanelNo_Clicked()
    {
        On_TurnOffButton_Clicked();
        Play_SFX_Clicked();

    }

    public void On_Browser_Clicked()
    {
        BrowserPage.SetActive(true);
        Play_SFX_Clicked();

    }

    public void On_BrowserCloseButton_Clicked()
    {
        BrowserPage.SetActive(false);
        Play_SFX_Clicked();

    }

    public void On_Email_Clicked()
    {
        EmailPage.SetActive(true);
        Play_SFX_Clicked();

    }

    public void On_EmailPageCloseButton_Clicked()
    {
        EmailPage.SetActive(false);
        Play_SFX_Clicked();

    }

    public void On_EmailCard_Clicked()
    {
        print("Hello");
    }

    public void On_Remote_Clicked()
    {
        RemotePage.SetActive(true);
        Play_SFX_Clicked();

    }

    public void On_RemotePageBackButton_Clicked()
    {
        RemotePage.SetActive(false);
        Play_SFX_Clicked();

    }

    private void Play_SFX_Clicked()
    {
        SFX.Play();
    }
    #region Enter Scene
    public void OnClicked_Horror()
    {
        Debug.Log("Open Horror Level");
        HorrorScenePanel horrorScenePanel = new HorrorScenePanel();
        GameManager.getInstance().horrorScenePanel = horrorScenePanel;
        UIManager.getInstance().push(horrorScenePanel);
        
    }

    public void OnCLicked_Romance()
    {
        Debug.Log("Open Romance Level");
        LoveScenePanel loveScenePanel = new LoveScenePanel();
        GameManager.getInstance().LoveScenePanel = loveScenePanel;
        UIManager.getInstance().push(loveScenePanel);
    }
    
    public void OnCLicked_Disaster()
    {
        Debug.Log("Open Disaster Level");
        DisasterScenePanel disasterScenePanel = new DisasterScenePanel();
        GameManager.getInstance().disasterScenePanel = disasterScenePanel;
        UIManager.getInstance().push(disasterScenePanel);
    }
    #endregion
    #region ExitScene
    public void passHorror()
    {
        UIManager.getInstance().pop(true);
        disableBtn(0, 1,false);
    }
    public void passLove()
    {
        UIManager.getInstance().pop(true);
        disableBtn(1, 2,false);
    }
    public void passDisaster()
    {
        UIManager.getInstance().pop(true);
        disableBtn(2, 3,true);

    }
    private void disableBtn(int curLevel,int nextLevel,bool isLast)
    {
        
        Emails[curLevel+2].SetActive(true);

        Level_Buttons[curLevel].interactable = false;
        Level_Active[curLevel] = false;
        if(!isLast)
        {
            Level_Active[nextLevel] = true;
            Level_Buttons[nextLevel].interactable = true;
        }
        
    }
    private void findObj()
    {

        string[] s = new string[] {
            "RemotePage",
            "Apps",
            "Background",
            "TaskBar",
        };
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i] = GameObject.Find(s[i]);
        }
    }
    public void clear(bool isEnterScene)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(!isEnterScene);
        }
    }
    #endregion
}

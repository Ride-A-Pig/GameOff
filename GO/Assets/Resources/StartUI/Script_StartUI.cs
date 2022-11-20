using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Script_StartUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI TimeDisplay;
    [SerializeField] GameObject TurnOffPanel;
    [SerializeField] GameObject BrowserPage;
    [SerializeField] GameObject EmailPage;
    [SerializeField] GameObject RemotePage;
    bool bTurnOffPanel = false;
    void Start()
    {
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
    }

    public void On_TurnOffPanelYes_Clicked()
    {
        Application.Quit();
    }

    public void On_TurnOffPanelNo_Clicked()
    {
        On_TurnOffButton_Clicked();
    }

    public void On_Browser_Clicked()
    {
        BrowserPage.SetActive(true);
    }

    public void On_BrowserCloseButton_Clicked()
    {
        BrowserPage.SetActive(false);
    }

    public void On_Email_Clicked()
    {
        EmailPage.SetActive(true);
    }

    public void On_EmailPageCloseButton_Clicked()
    {
        EmailPage.SetActive(false);
    }

    public void On_EmailCard_Clicked()
    {
        print("Hello");
    }

    public void On_Remote_Clicked()
    {
        RemotePage.SetActive(true);
    }

    public void On_RemotePageBackButton_Clicked()
    {
        RemotePage.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Script_StartUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI TimeDisplay;
    [SerializeField] GameObject TurnOffPanel;
    bool bTurnOffPanel = false;
    void Start()
    {
        TurnOffPanel.SetActive(false);
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

}

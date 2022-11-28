using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmailCard : MonoBehaviour
{
    [SerializeField] string topic_text;
    [SerializeField] string content_text = "Nice to meet you";
    [SerializeField] TMPro.TextMeshProUGUI topic;
    [SerializeField] TMPro.TextMeshProUGUI content;


    public void On_Card_Clicked()
    {
        topic.text = topic_text;
        content.text = content_text;
    }


}

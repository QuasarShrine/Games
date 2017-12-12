using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{

    private Text thisText;


    // Use this for initialization
    void Start() {
        thisText = GetComponent<Text>();
        ClearText();
    }

    public void SetText(string txt) {
        int hour = System.DateTime.Now.Hour;
        int second = System.DateTime.Now.Second;
        string timeStr = hour.ToString() + "h" + second.ToString() + "s ";
        thisText.text = timeStr + ":" + txt;
        Invoke("ClearText", 3);

    }

    public void ClearText() {
        thisText.text = "";
    }
}

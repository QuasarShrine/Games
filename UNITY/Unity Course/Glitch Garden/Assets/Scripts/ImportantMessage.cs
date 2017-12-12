using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportantMessage : MonoBehaviour {

    private Text thisText;


    // Use this for initialization
    void Start() {
        thisText = GetComponent<Text>();
        ClearText();
    }

    public void SetText(string txt) {
        thisText.text = txt;
        Invoke("ClearText", 3);

    }

    public void ClearText() {
        thisText.text = "";
    }
}

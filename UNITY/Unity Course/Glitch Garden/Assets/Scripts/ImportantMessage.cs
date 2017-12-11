using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportantMessage : MonoBehaviour {

    private Text thisText;


	// Use this for initialization
	void Start () {
        thisText = GetComponent<Text>();
        SetText("");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetText(string txt) {
        thisText.text = txt;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private SpriteRenderer sprite;
    private Button[] buttonList;
    public GameObject defender;

    public static GameObject selectedDefender;

	// Use this for initialization
	void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.black;
        buttonList = GameObject.FindObjectsOfType<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        foreach (Button btn in buttonList) {
            btn.GetComponent<SpriteRenderer>().color = Color.black;
        }
        sprite.color = Color.white;
        selectedDefender = defender;
    }
}

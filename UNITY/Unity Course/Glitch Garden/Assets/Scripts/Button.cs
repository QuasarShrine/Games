using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    private SpriteRenderer sprite;
    private Button[] buttonList;
    private Text costTxt;
    private StarDisplay starDisplay;
    private int defenderCost;

    public GameObject defender;

    public static GameObject selectedDefender;

	// Use this for initialization
	void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.black;
        buttonList = GameObject.FindObjectsOfType<Button>();
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        defenderCost = defender.GetComponent<Defender>().starCost;
        costTxt = transform.Find("Cost").GetComponent<Text>();
        costTxt.text = defenderCost.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if(starDisplay.GetStarsAmount() < defenderCost) {
            costTxt.color = Color.red;
        } else {
            costTxt.color = Color.yellow;
        }
	}

    private void OnMouseDown() {
        foreach (Button btn in buttonList) {
            btn.GetComponent<SpriteRenderer>().color = Color.black;
        }
        sprite.color = Color.white;
        selectedDefender = defender;
    }
}

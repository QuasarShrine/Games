using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{

    public Text standingDisplay;
    private Pin[] allPins;

    // Use this for initialization
    void Start() {
        allPins = GameObject.FindObjectsOfType<Pin>();
    }

    // Update is called once per frame
    void Update() {
        standingDisplay.text = CountStanding().ToString();
    }

    public int CountStanding() {
        int nbStandingPins = 0;
        foreach (var pin in allPins) {
            if (pin.IsStanding()) { nbStandingPins++; }
        }
        return nbStandingPins;
    }
}

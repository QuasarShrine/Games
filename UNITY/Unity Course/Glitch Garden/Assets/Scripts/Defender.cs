using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int starCost = 100;
    public int generatedStarAmount = 0;
    private StarDisplay starDisplay;

    private void Start() {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void AddStars() {
        starDisplay.AddStars(generatedStarAmount);
    }
}

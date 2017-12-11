using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HitPointsDisplay : MonoBehaviour
{

    public int hitPoints = 3;
    private LevelManager levelManager;

    private Text hitPointsText;

    // Use this for initialization
    void Start() {
        hitPointsText = GetComponent<Text>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        UpdateDisplay();
    }

    public void AddLives(int amount) {
        hitPoints += amount;
        UpdateDisplay();
    }

    public void LoseLife() {
        if (hitPoints >= 1) {
            hitPoints -= 1;
            UpdateDisplay();
        }

        if(hitPoints <= 0) {
            Lose();
        }
    }

    private void Lose() {
        levelManager.LoadLevel("03b Lose");
    }

    private void UpdateDisplay() {
        hitPointsText.text = hitPoints.ToString();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{

    public static int _STARS;

    private Text starText;

    public void AddStars(int amount) {
        _STARS += amount;
        UpdateDisplay();
    }

    public void UseStars(int amount) {
        _STARS -= amount;
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        starText.text = _STARS.ToString();

    }

    // Use this for initialization
    void Start() {
        starText = GetComponent<Text>();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{

    public static int _STARS;
    public enum Status { SUCCESS, FAILURE };

    private Text starText;

    public void AddStars(int amount) {
        _STARS += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount) {
        if (_STARS >= amount) {
            _STARS -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateDisplay() {
        starText.text = _STARS.ToString();

    }

    // Use this for initialization
    void Start() {
        starText = GetComponent<Text>();
        _STARS = 60;
        UpdateDisplay();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{

    private bool isActive = false;

    // Use this for initialization
    void Start() {
        gameObject.SetActive(isActive);
    }

    // Update is called once per frame
    void Update() {

    }

    public void ActivatePopup() {
        if (!isActive) {
            isActive = true;
            PauseGame();
            gameObject.SetActive(isActive);
        }
    }

    public void DesactivePopup() {
        if (isActive) {
            isActive = false;
            UnPauseGame();
            gameObject.SetActive(isActive);
        }
    }



    public void PauseGame() {
        Time.timeScale = 0;
    }


    public void UnPauseGame() {
        Time.timeScale = 1;
    }

    public bool IsActive() {
        return isActive;
    }
}

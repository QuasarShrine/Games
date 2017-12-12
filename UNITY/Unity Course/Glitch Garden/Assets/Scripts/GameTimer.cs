using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    private Slider slider;
    private ImportantMessage importantMessage;
    private LevelManager levelManager;
    private bool gameWon;

    public AudioClip winSound;


    [Tooltip("Set the level's time duration (seconds)")]
    [Range(10, 240)]
    public float duration;

    // Use this for initialization
    void Start() {
        slider = GetComponent<Slider>();
        gameWon = false;
        importantMessage = GameObject.FindObjectOfType<ImportantMessage>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {
        float timeSinceStart = Time.timeSinceLevelLoad;
        if (timeSinceStart >= duration && !gameWon) {
            Win();
        } else {
            slider.value = timeSinceStart / duration;
        }
    }

    public void Win() {
        importantMessage.SetText("You survived " + duration + "s ! Congratulations !");
        AudioSource.PlayClipAtPoint(winSound, transform.position);
        gameWon = true;
        Invoke("LoadNextLevel", winSound.length);
    }

    public void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }
}

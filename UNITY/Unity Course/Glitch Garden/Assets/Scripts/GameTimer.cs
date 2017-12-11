using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    private Slider slider;
    public AudioClip winSound;

    public ImportantMessage importantMessage;

    [Tooltip("Set the level's time duration (seconds)")]
    [Range(10, 240)]
    public float duration;

    // Use this for initialization
    void Start() {
        slider = GetComponent<Slider>();
        importantMessage = GameObject.FindObjectOfType<ImportantMessage>();
    }

    // Update is called once per frame
    void Update() {
        float timeSinceStart = Time.timeSinceLevelLoad;
        if (timeSinceStart >= duration) {
            Win();
        } else {
            slider.value = timeSinceStart / duration;
        }
    }

    public void Win() {
        importantMessage.SetText("You survived " + duration + "s ! Congratulations !");
    }
}

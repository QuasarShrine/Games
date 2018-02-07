using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public Text standingDisplay;
    public int lastStandingCount = -1;

    private float lastChangedTime;
    private bool ballEnteredBox = false;
    private Ball ball;


    // Use this for initialization
    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() {
        standingDisplay.text = CountStanding().ToString();

        if (ballEnteredBox) {
            CheckStanding();
        }
    }

    void CheckStanding() {
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount) {
            lastChangedTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f;
        if ((Time.time - lastChangedTime) > settleTime) {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled() {
        lastStandingCount = -1; // new game
        ballEnteredBox = false;
        ball.Reset();
        standingDisplay.color = Color.green;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Ball>()) {
            standingDisplay.color = Color.red;
            ballEnteredBox = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<Pin>()) {
            Destroy(other.gameObject);
        }
    }
    
    public int CountStanding() {
        int nbStandingPins = 0;
        foreach (var pin in GameObject.FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) { nbStandingPins++; }
        }
        return nbStandingPins;
    }

    public void TriggerReset() {
        GetComponent<Animator>().SetTrigger("resetTrigger");
    }

    public void TriggerTidy() {
        GetComponent<Animator>().SetTrigger("tidyTrigger");
    }
}

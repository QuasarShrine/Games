using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public Text standingDisplay;
    public int lastStandingCount = -1;
    public GameObject pinSet;

    private float lastChangedTime;
    private int lastSettledCount = 10;

    private bool ballLeftBox = false;
    private Ball ball;

    private ActionMaster actionMaster = new ActionMaster();
    private Animator animatior;


    // Use this for initialization
    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
        animatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        standingDisplay.text = CountStanding().ToString();

        if (ballLeftBox) {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    void UpdateStandingCountAndSettle() {
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
        int pinFallen = lastSettledCount - CountStanding();
        lastSettledCount = CountStanding();
        ActionMaster.Action action = actionMaster.Bowl(pinFallen);
        switch (action) {
            case ActionMaster.Action.Tidy:
                animatior.SetTrigger("tidyTrigger");
                break;
            case ActionMaster.Action.Reset:
                animatior.SetTrigger("resetTrigger");
                lastSettledCount = 10;
                break;
            case ActionMaster.Action.EndTurn:
                animatior.SetTrigger("resetTrigger");
                lastSettledCount = 10;
                break;
            case ActionMaster.Action.EndGame:
                throw new UnityException("Don't know how to handle endgame yet!");
            default:
                break;
        }

        lastStandingCount = -1; // new game
        ballLeftBox = false;
        ball.Reset();
        standingDisplay.color = Color.green;
    }

    public void RaisePins() {
        //raise standing pin only by distancetoraise
        foreach (var pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.RaiseIfStanding();
        }

    }

    public void LowerPins() {
        foreach (var pin in GameObject.FindObjectsOfType<Pin>()) {
            pin.Lower();
        }

    }

    public void RenewPins() {
        Instantiate(pinSet, new Vector3(0f, 1f, 1829f), Quaternion.identity);
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

    public void SetBallLeftBox(bool val) {
        ballLeftBox = val;
    }
}

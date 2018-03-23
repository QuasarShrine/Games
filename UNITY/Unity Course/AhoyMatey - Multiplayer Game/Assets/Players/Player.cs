using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
using UnityEngine;

public class Player : NetworkBehaviour
{

    private Vector3 inputValues;

    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {
        if (!isLocalPlayer) {
            return;
        }
        inputValues.x = CrossPlatformInputManager.GetAxis("Horizontal");
        inputValues.y = 0f;
        inputValues.z = CrossPlatformInputManager.GetAxis("Vertical");

        transform.Translate(inputValues);
    }
    public override void OnStartLocalPlayer() {
        GetComponentInChildren<Camera>().enabled = true;
    }
}

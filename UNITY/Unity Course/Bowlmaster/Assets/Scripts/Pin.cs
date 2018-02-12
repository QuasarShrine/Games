using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public float standingThreshold;

    public float distToRaise = 40f;

    private Rigidbody pinRigidBody;

    public void Start() {
        pinRigidBody = GetComponent<Rigidbody>();
    }

    public bool IsStanding() {
        if (Mathf.Abs(270 - transform.eulerAngles.x) < standingThreshold && Mathf.Abs(transform.eulerAngles.z) < standingThreshold) {
            return true;
        } else {
            return false;
        }
    }

    public void RaiseIfStanding() {
        if (IsStanding()) {
            pinRigidBody.useGravity = false;
            gameObject.transform.Translate(new Vector3(0f, distToRaise, 0f), Space.World);
        }
    }

    public void Lower() {
        gameObject.transform.Translate(new Vector3(0f, -distToRaise, 0f), Space.World);
        pinRigidBody.useGravity = true;
    }

}

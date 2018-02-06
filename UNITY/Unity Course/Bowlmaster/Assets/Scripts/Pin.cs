using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public float standingThreshold;

    public bool IsStanding() {
        if (Mathf.Abs(270 - transform.eulerAngles.x) < standingThreshold && Mathf.Abs(transform.eulerAngles.z) < standingThreshold) {
            return true;
        } else {
            return false;
        }
    }

}

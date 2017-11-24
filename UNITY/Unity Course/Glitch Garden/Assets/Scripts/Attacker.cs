using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range (0f,2f)]
    public float currentSpeed;

    private GameObject currentTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);	
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log(name + " trigger enter with " + collision.gameObject.name);
        SetCurrentTarget(collision.gameObject);
    }

    public float GetSpeed() {
        return currentSpeed;
    }
    public void SetSpeed(float val) {
        currentSpeed = val;
    }

    public void StrikeCurrentTarget(float damage) {
        if (currentTarget != null) {
            Debug.Log(name + " is dealing " + damage + " damage on "+ currentTarget.name);
        } else {
            Debug.LogError("No currentTarget defined for " + name);
        }
    }

    public void SetCurrentTarget(GameObject target) {
        currentTarget = target;
    }
}

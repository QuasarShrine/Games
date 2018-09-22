using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour {

  public KeyCode triggerKey;
  [Range(8f,30f)]
  public float power;

  private Rigidbody2D body2D;

	// Use this for initialization
	void Start () {
    body2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    if (Input.GetKey(triggerKey)) {
      body2D.AddRelativeForce(Vector2.up * power);
    }
	}
}

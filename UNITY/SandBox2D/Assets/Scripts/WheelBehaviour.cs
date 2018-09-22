using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBehaviour : MonoBehaviour {

  public KeyCode leftKey;
  public KeyCode rightKey;

  [Range(1f,10f)]
  public float acceleration;

  private Rigidbody2D body2D;

	// Use this for initialization
	void Start () {
    body2D = GetComponent<Rigidbody2D>();

  }
	
	// Update is called once per frame
	void FixedUpdate () {
    if (Input.GetKey(leftKey)) {
      body2D.AddForce(Vector2.left * acceleration);
    }

    if (Input.GetKey(rightKey)) {
      body2D.AddForce(Vector2.right * acceleration);
    }
  }


}

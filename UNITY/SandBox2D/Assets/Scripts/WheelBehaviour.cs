using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBehaviour : MonoBehaviour {

  [Range(1f,10f)]
  public float acceleration;

  private Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
    rigidbody2D = GetComponent<Rigidbody2D>();

  }
	
	// Update is called once per frame
	void FixedUpdate () {
    if (Input.GetKey(KeyCode.LeftArrow)) {
      rigidbody2D.AddForce(Vector2.left * acceleration);
    }

    if (Input.GetKey(KeyCode.RightArrow)) {
      rigidbody2D.AddForce(Vector2.right * acceleration);
    }
  }


}

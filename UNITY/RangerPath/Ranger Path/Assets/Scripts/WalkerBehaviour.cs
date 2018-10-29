using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerBehaviour : MonoBehaviour {

  public KeyCode leftKey = KeyCode.LeftArrow;
  public KeyCode rightKey = KeyCode.RightArrow;
  public KeyCode jumpKey = KeyCode.Space;
  public KeyCode runKey = KeyCode.LeftShift;

  [Range(5f, 20f)]
  public float speed = 5f;
  [Range(1f, 5f)]
  public float runSpeedFactor = 2f;
  [Range(300f, 500f)]
  public float jumpForce = 300f;

  private Rigidbody2D body2D;
  private bool isOnGround = false;

  // Use this for initialization
  void Start() {
    body2D = GetComponent<Rigidbody2D>();

  }

  private void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.CompareTag("Ground")) {
      isOnGround = true;
    }
  }

  // Update is called once per frame
  void FixedUpdate() {
    if (Input.GetKey(leftKey)) {
      if (Input.GetKey(runKey)) {
        transform.Translate(Vector2.left * (speed / 100) * runSpeedFactor);
      } else {
        transform.Translate(Vector2.left * speed / 100);
      }
    }

    if (Input.GetKey(rightKey)) {
      if (Input.GetKey(runKey)) {
        transform.Translate(Vector2.right * (speed / 100) * runSpeedFactor);
      } else {
        transform.Translate(Vector2.right * speed / 100);
      }
    }

    if (Input.GetKeyDown(jumpKey) && isOnGround) {
      body2D.AddForce(Vector2.up * jumpForce);
      isOnGround = false;
    }
    //Debug.Log(isOnGround);
  }
}

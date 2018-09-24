using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpgMovement : MonoBehaviour {

  public bool moveStepByStep = false;
  public KeyCode leftKey = KeyCode.LeftArrow;
  public KeyCode rightKey = KeyCode.RightArrow;
  public KeyCode upKey = KeyCode.UpArrow;
  public KeyCode downKey = KeyCode.DownArrow;
  public KeyCode jumpKey = KeyCode.Space;
  public KeyCode runKey = KeyCode.LeftShift;

  public Collider2D uptColl;
  public Collider2D upRightColl;
  public Collider2D rightColl;
  public Collider2D downRightColl;
  public Collider2D downColl;
  public Collider2D downLeftColl;
  public Collider2D leftColl;
  public Collider2D upLeftColl;

  [Range(5f, 20f)]
  public float speed = 5f;
  [Range(1f, 5f)]
  public float runSpeedFactor = 2f;

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if (moveStepByStep) {
      StepMove();
    } else {
      FreeMove();
    }
  }

  public void FreeMove() {
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

    if (Input.GetKey(upKey)) {
      if (Input.GetKey(runKey)) {
        transform.Translate(Vector2.up * (speed / 100) * runSpeedFactor);
      } else {
        transform.Translate(Vector2.up * speed / 100);
      }
    }

    if (Input.GetKey(downKey)) {
      if (Input.GetKey(runKey)) {
        transform.Translate(Vector2.down * (speed / 100) * runSpeedFactor);
      } else {
        transform.Translate(Vector2.down * speed / 100);
      }
    }
  }

  public void StepMove() {
    if (Input.GetKeyDown(leftKey)) {
      transform.Translate(Vector2.left);
      
    }

    if (Input.GetKeyDown(rightKey)) {
      transform.Translate(Vector2.right);
    }

    if (Input.GetKeyDown(upKey)) {
      transform.Translate(Vector2.up);
    }

    if (Input.GetKeyDown(downKey)) {
      transform.Translate(Vector2.down);
    }
  }
}

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

  public Collider2D upColl;
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

  private List<Collider2D> colliders = new List<Collider2D>();

  [HideInInspector()]
  public enum Direction {
    up,
    upRight,
    right,
    downRight,
    down,
    downLeft,
    left,
    upLeft
  }

  private List<Direction> canNotGoDir = new List<Direction>();
  //private List<Direction> canNotGoDir;


  // Use this for initialization
  void Start() {
    Init();
  }

  // Update is called once per frame
  void Update() {
    if (moveStepByStep) {
      StepMove();
    } else {
      FreeMove();
    }
  }

  public void OnTriggerStay2D(Collider2D collision) {
    if (collision.gameObject.CompareTag("Ground")) {
      if (upColl.IsTouching(collision)) {
        canNotGoDir.Add(Direction.up);
      } else {
        if (canNotGoDir.Contains(Direction.up)) {
          canNotGoDir.Remove(Direction.up);
        }
      }
      if (upRightColl.IsTouching(collision)) {
        canNotGoDir.Add(Direction.upRight);
      } else {
        if (canNotGoDir.Contains(Direction.upRight)) {
          canNotGoDir.Remove(Direction.upRight);
        }
      }
      if (rightColl.IsTouching(collision)) {
        canNotGoDir.Add(Direction.right);
      } else {
        if (canNotGoDir.Contains(Direction.right)) {
          canNotGoDir.Remove(Direction.right);
        }
      }
      if (downRightColl.IsTouching(collision)) {
        canNotGoDir.Add(Direction.downRight);
      } else {
        if (canNotGoDir.Contains(Direction.downRight)) {
          canNotGoDir.Remove(Direction.downRight);
        }
      }
      if (downColl.IsTouching(collision)) {
        canNotGoDir.Add(Direction.down);
      } else {
        if (canNotGoDir.Contains(Direction.down)) {
          canNotGoDir.Remove(Direction.down);
        }
      }
      if (downLeftColl.IsTouching(collision)) {
        canNotGoDir.Add(Direction.downLeft);
      } else {
        if (canNotGoDir.Contains(Direction.downLeft)) {
          canNotGoDir.Remove(Direction.downLeft);
        }
      }
      if (leftColl.IsTouching(collision)) {
        canNotGoDir.Add(Direction.left);
      } else {
        if (canNotGoDir.Contains(Direction.left)) {
          canNotGoDir.Remove(Direction.left);
        }
      }
      if (upLeftColl.IsTouching(collision)) {
        canNotGoDir.Add(Direction.upLeft);
      } else {
        if (canNotGoDir.Contains(Direction.upLeft)) {
          canNotGoDir.Remove(Direction.upLeft);
        }
      }
    }
    Debug.Log(canNotGoDir);
  }


  //public bool CanGo(Direction dir) {
  //  bool can = false;
  //  switch (dir) {
  //    case Direction.up:
  //      if(upColl)
  //      break;
  //    case Direction.upRight:
  //      break;
  //    case Direction.right:
  //      break;
  //    case Direction.downRight:
  //      break;
  //    case Direction.down:
  //      break;
  //    case Direction.downLeft:
  //      break;
  //    case Direction.left:
  //      break;
  //    case Direction.upLeft:
  //      break;
  //    default:
  //      break;
  //  }

  //  return can;
  //}

  public void Init() {

    if (upColl) {
      colliders.Add(upColl);
    } else {
      Debug.LogError("RpgMovement : Upper collider need to be set");
    }

    if (upRightColl) {
      colliders.Add(upRightColl);
    } else {
      Debug.LogError("RpgMovement : Upper Right collider need to be set");
    }


    if (rightColl) {
      colliders.Add(rightColl);
    } else {
      Debug.LogError("RpgMovement : Right collider need to be set");
    }


    if (downRightColl) {
      colliders.Add(downRightColl);
    } else {
      Debug.LogError("RpgMovement : Down right collider need to be set");
    }


    if (downColl) {
      colliders.Add(downColl);
    } else {
      Debug.LogError("RpgMovement : Down collider need to be set");
    }


    if (downLeftColl) {
      colliders.Add(downLeftColl);
    } else {
      Debug.LogError("RpgMovement : Down left collider need to be set");
    }


    if (leftColl) {
      colliders.Add(leftColl);
    } else {
      Debug.LogError("RpgMovement : Left collider need to be set");
    }

    if (upLeftColl) {
      colliders.Add(upLeftColl);
    } else {
      Debug.LogError("RpgMovement : Upper left collider need to be set");
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
      if (Input.GetKey(runKey) && !canNotGoDir.Contains(Direction.right)) {
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

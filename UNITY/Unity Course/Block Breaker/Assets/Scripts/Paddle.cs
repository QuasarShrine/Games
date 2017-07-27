using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public Sprite spriteSmall, spriteNorm, spriteBig;

    public enum AllpaddleSize { small, norm, big };
    public AllpaddleSize paddleSize;
    private Ball ball;
    private PolygonCollider2D[] colliders;

    private void Awake() {
        colliders = gameObject.GetComponents<PolygonCollider2D>();
    }

    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
        paddleSize = AllpaddleSize.norm;
    }

    // Update is called once per frame
    void Update() {
        if (!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
    }

    void MoveWithMouse() {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }

    void AutoPlay() {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
        Vector3 ballPostion = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPostion.x, 0.5f, 15.5f);
        this.transform.position = paddlePos;
    }


    private AllpaddleSize GetPaddleSize() {
        return this.paddleSize;
    }

    public void IncreasePaddleSize() {
        AllpaddleSize pSize = this.GetPaddleSize();
        switch (pSize) {
            case AllpaddleSize.small:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteNorm;
                paddleSize = AllpaddleSize.norm;
                EnableCollider(paddleSize);
                break;
            case AllpaddleSize.norm:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteBig;
                paddleSize = AllpaddleSize.big;
                EnableCollider(paddleSize);
                break;
        }
    }

    public void DecreasePaddleSize() {
        AllpaddleSize pSize = this.GetPaddleSize();
        switch (pSize) {
            case AllpaddleSize.norm:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteSmall;
                paddleSize = AllpaddleSize.small;
                EnableCollider(paddleSize);
                break;
            case AllpaddleSize.big:
                gameObject.GetComponent<SpriteRenderer>().sprite = spriteNorm;
                paddleSize = AllpaddleSize.norm;
                EnableCollider(paddleSize);
                break;
        }
    }

    private void EnableCollider(AllpaddleSize cSize) {
        switch (cSize) {
            case AllpaddleSize.small:
                colliders[0].enabled = true;
                colliders[1].enabled = false;
                colliders[2].enabled = false;
                break;
            case AllpaddleSize.norm:
                colliders[0].enabled = false;
                colliders[1].enabled = true;
                colliders[2].enabled = false;
                break;
            case AllpaddleSize.big:
                colliders[0].enabled = false;
                colliders[1].enabled = false;
                colliders[2].enabled = true;
                break;
        }
    }
}

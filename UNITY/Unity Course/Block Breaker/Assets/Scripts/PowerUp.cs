using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public enum puTypes { plusSize, minusSize };

    [Header("PowerUp type")]
    public puTypes puType;

    private Paddle paddle;

    // Use this for initialization
    void Start() {
        paddle = GameObject.FindObjectOfType<Paddle>();

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Paddle")) {
            switch (puType) {
                case puTypes.plusSize:
                    paddle.IncreasePaddleSize();
                    break;
                case puTypes.minusSize:
                    paddle.DecreasePaddleSize();
                    break;
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("LooseCollider")) {
            Destroy(gameObject);
        }
    }

}

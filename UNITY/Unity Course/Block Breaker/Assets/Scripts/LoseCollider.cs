using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private GameManager gameManager;

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.gameObject.CompareTag("Ball")) {
            gameManager = GameObject.FindObjectOfType<GameManager>();
            gameManager.LoseAlife();

        }
    }

    //	void OnTriggerEnter2D(Collider2D trigger) {
    //		print("Triggered !");
    //	}

}

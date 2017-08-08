using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private GameManager gameManager;

    public AudioClip fail;

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.gameObject.CompareTag("Ball")) {
            AudioSource.PlayClipAtPoint(fail,transform.position);
            gameManager = GameObject.FindObjectOfType<GameManager>();
            gameManager.LoseAlife();

        }
    }

}

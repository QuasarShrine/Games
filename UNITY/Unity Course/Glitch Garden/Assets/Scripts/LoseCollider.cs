using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private HitPointsDisplay hitPointsDisplay;

    private void Start() {
        hitPointsDisplay = GameObject.FindObjectOfType<HitPointsDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Attacker>()) {
            hitPointsDisplay.LoseLife();
        }
        Destroy(collision.gameObject);
    }


}

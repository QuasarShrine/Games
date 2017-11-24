using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

    private Attacker attacker;
    private Animator animator;
    //private GameObject target;

	// Use this for initialization
	void Start () {
        attacker = gameObject.GetComponent<Attacker>();
        animator = gameObject.GetComponent<Animator>();


    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Gravestone") {
            Debug.Log("Fox jump over");
            FoxJump();
        }

        if (collision.gameObject.name == "Gnome" || collision.gameObject.name == "Cactus" || collision.gameObject.name == "StarTrophy") {
            FoxAttack(collision.gameObject);
        }
    }

    private void FoxJump() {
        animator.SetTrigger("jump");
    }

    private void FoxAttack(GameObject target) {
        animator.SetBool("isAttacking", true);
        attacker.SetCurrentTarget(target);
        attacker.StrikeCurrentTarget(5);
    }


    // Update is called once per frame
    void Update () {
		
	}
}

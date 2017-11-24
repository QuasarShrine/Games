using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {

    private Attacker attacker;
    private Animator animator;
    //private GameObject target;

	// Use this for initialization
	void Start () {
        attacker = gameObject.GetComponent<Attacker>();
        animator = gameObject.GetComponent<Animator>();


    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.name == "Gravestone" || collision.gameObject.name == "Gnome" || collision.gameObject.name == "Cactus" || collision.gameObject.name == "StarTrophy") {
            LizardAttack(collision.gameObject);
        }
    }

    private void LizardAttack(GameObject target) {
        animator.SetBool("isAttacking", true);
        attacker.SetCurrentTarget(target);
        attacker.StrikeCurrentTarget(10);
    }


    // Update is called once per frame
    void Update () {
		
	}
}

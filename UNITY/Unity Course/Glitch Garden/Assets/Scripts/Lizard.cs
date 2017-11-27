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

        if (collision.gameObject.GetComponent<Defender>()) {
            LizardAttack(collision.gameObject);
        }
    }

    private void LizardAttack(GameObject target) {
        animator.SetBool("isAttacking", true);
        attacker.Attack(target);
    }


    // Update is called once per frame
    void Update () {
		
	}
}

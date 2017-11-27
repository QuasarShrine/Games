using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{

    private Attacker attacker;
    private Animator animator;
    //private GameObject target;

    // Use this for initialization
    void Start() {
        attacker = gameObject.GetComponent<Attacker>();
        animator = gameObject.GetComponent<Animator>();


    }

    private void OnTriggerEnter2D(Collider2D collision) {


        if (!collision.gameObject.GetComponent<Defender>()) {
            return;
        } else if (collision.gameObject.GetComponent<Wall>()) {
            FoxJump();
        } else {
            FoxAttack(collision.gameObject);
        }

    }

    private void FoxJump() {
        animator.SetTrigger("jump");
    }

    private void FoxAttack(GameObject target) {
        animator.SetBool("isAttacking", true);
        attacker.Attack(target);
    }


    // Update is called once per frame
    void Update() {

    }
}

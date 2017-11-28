using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{

    [Range(0f, 2f)]
    public float currentSpeed;

    private GameObject currentTarget;

    private Animator animator;

    // Use this for initialization
    void Start() {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget) {
            animator.SetBool("isAttacking", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //Debug.Log(name + " trigger enter with " + collision.gameObject.name);
    }

    public float GetSpeed() {
        return currentSpeed;
    }

    public void SetSpeed(float val) {
        currentSpeed = val;
    }

    public void StrikeCurrentTarget(int damage) {
        if (currentTarget) {
            Debug.Log(name + " is dealing " + damage + " damage on " + currentTarget.name);
            currentTarget.GetComponent<Health>().LoseHealthPoints(damage);
        }
    }

    public void Attack(GameObject target) {
        currentTarget = target;
    }
}

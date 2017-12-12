using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{

    [Range(0f, 2f)]
    public float currentSpeed;

    [Tooltip("Average number of seconds between appearences")]
    public float seenEverySeconds;


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
    }

    public float GetSpeed() {
        return currentSpeed;
    }

    public void SetSpeed(float val) {
        currentSpeed = val;
    }

    public void StrikeCurrentTarget(int damage) {
        if (currentTarget) {
            currentTarget.GetComponent<Health>().LoseHealthPoints(damage);
            if (currentTarget.GetComponent<Wall>()) {
                currentTarget.GetComponent<Wall>().IsAttacked();
            }
        }
    }

    public void Attack(GameObject target) {
        currentTarget = target;
    }

    public float GetSeenEverySeconds() {
        return seenEverySeconds;
    }
}

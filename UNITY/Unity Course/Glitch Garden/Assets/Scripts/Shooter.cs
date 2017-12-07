using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start() {
        projectileParent = GameObject.Find("Projectiles");
        animator = gameObject.GetComponent<Animator>();
        if (projectileParent == null) {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    void SetMyLaneSpawner() {
        Spawner[] allSpawners = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in allSpawners) {
            if (spawner.transform.position.y == transform.position.y) {
                myLaneSpawner = spawner;

                Debug.Log("spawner "+spawner+ " for "+name+" at "+ spawner.transform.position.y);
                return;
            }
        }
        Debug.LogError(name + " have no lane spawner attached");
    }

    private void Update() {
        if (IsAttackerAheadInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerAheadInLane() {
        int nbChidlren = myLaneSpawner.gameObject.transform.childCount;
        bool isAttackerAheadInLane = false;
        if (nbChidlren > 0) {
            foreach (Transform child in myLaneSpawner.transform) {
                if (gameObject.transform.position.x < child.transform.position.x) {
                    isAttackerAheadInLane = true;
                }
            }
        }
        return isAttackerAheadInLane;
    }

    private void FireGun() {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}

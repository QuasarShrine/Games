using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;

    private void Start() {
        projectileParent = GameObject.Find("Projectiles");

        if(projectileParent == null) {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void FireGun() {
        GameObject newProjectile =  Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
}

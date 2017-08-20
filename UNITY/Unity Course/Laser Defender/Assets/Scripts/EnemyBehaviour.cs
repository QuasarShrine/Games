using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private float health = 150f;

    public GameObject weaponType;
    public float projectileSpeed;
    public float fireRate;

    void Fire() {
        GameObject projectile = Instantiate(weaponType, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
    }

    private void Start() {
        InvokeRepeating("Fire", 1f , fireRate);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile) {
            health -= projectile.GetDamage();
            //Debug.Log(projectile.GetDamage());
            projectile.Hit();
            if (health <= 0) {
                CancelInvoke("Fire");
                Destroy(gameObject);
            }

        }
    }
}

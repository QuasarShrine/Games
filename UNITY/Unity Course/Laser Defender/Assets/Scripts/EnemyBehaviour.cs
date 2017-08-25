using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private float health = 150f;

    public GameObject weaponType;
    public float projectileSpeed;
    public float fireRate;
    public int scoreValue = 150;

    public float shotsPerSeconds = 0.5f;

    public AudioClip hurt;

    private ScoreKeeper scoreKeeper;

    private void Start() {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Fire() {
        GameObject projectile = Instantiate(weaponType, new Vector3(transform.position.x, transform.position.y - 0.7f, 0), Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        projectile.GetComponent<Projectile>().Shoot();
    }

    private void Update() {
        float probability = Time.deltaTime * shotsPerSeconds;
        if(Random.value < probability) {
            Fire();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {

        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile) {
            health -= projectile.GetDamage();
            projectile.Hit();
            AudioSource.PlayClipAtPoint(hurt, transform.position);
            if (health <= 0) {
                CancelInvoke("Fire");
                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);
            }

        }
    }
}

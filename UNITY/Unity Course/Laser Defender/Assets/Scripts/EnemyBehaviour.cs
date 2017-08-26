using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Properties")]
    public float health = 150f;
    public int scoreValue = 150;

    [Header("Weapon")]
    public GameObject weaponType;
    public float projectileSpeed;
    public float fireRate;
    public float shotsPerSeconds = 0.5f;


    [Header("Sounds effects")]
    public AudioClip hurt;
    public AudioClip die;

    private ScoreKeeper scoreKeeper;

    private void Start() {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Fire() {
        GameObject projectile = Instantiate(weaponType, transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
        projectile.GetComponent<Projectile>().Shoot();
        projectile.GetComponent<SpriteRenderer>().sortingLayerName = "EnemyProjectiles";
    }

    private void Update() {
        float probability = Time.deltaTime * shotsPerSeconds;
        if (Random.value < probability) {
            Fire();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {

        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile) {
            Hurt(projectile);
            if (health <= 0) {
                Die();
            }
        }
    }

    public void Hurt(Projectile projectile) {
        health -= projectile.GetDamage();
        AudioSource.PlayClipAtPoint(hurt, transform.position);
        projectile.Hit();
    }

    public void Die() {
        CancelInvoke("Fire");
        AudioSource.PlayClipAtPoint(die, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
    }
}

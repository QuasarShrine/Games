using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    public float health = 250f;
    public float speed = 15.0f; // number of pixels the ship will move every frame
    public float playSpacePadding = 0.5f;

    [Header("Weapon")]
    public GameObject weaponType;
    public float fireRate;

    [Header("Sounds Effects")]
    public AudioClip hurt;
    public AudioClip die;


    private float xmin, xmax, ymin, ymax;

    // Use this for initialization
    void Start() {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 uptmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        Vector3 bottommost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        xmin = leftmost.x + playSpacePadding;
        xmax = rightmost.x - playSpacePadding;
        ymax = uptmost.y - playSpacePadding;
        ymin = bottommost.y + playSpacePadding;
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
        AudioSource.PlayClipAtPoint(die, transform.position);
        Destroy(gameObject);
    }


    void Fire() {
        GameObject projectile = Instantiate(weaponType, transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectile.GetComponent<Projectile>().GetSpeed(), 0);
        projectile.GetComponent<Projectile>().Shoot();
        projectile.GetComponent<SpriteRenderer>().sortingLayerName = "PlayerProjectiles";
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            InvokeRepeating("Fire", 0.0000001f, fireRate);
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke("Fire");
        }

        MoveShip();
    }

    void MoveShip() {
        // using a temp variable to ensure we don't move the player too
        // far BEFORE restricting his X to playspace boundaries
        Vector3 tempPos = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            tempPos += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            tempPos += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            tempPos += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            tempPos += Vector3.down * speed * Time.deltaTime;
        }

        // restrict player to playspace boundaries
        float newX = Mathf.Clamp(tempPos.x, xmin, xmax);
        float newY = Mathf.Clamp(tempPos.y, ymin, ymax);
        transform.position = new Vector3(newX, newY, tempPos.z);
    }
}

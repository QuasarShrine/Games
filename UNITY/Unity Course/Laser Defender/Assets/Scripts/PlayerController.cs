using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float health = 250f;

    public GameObject weaponType;
    public float projectileSpeed;
    public float fireRate;

    public float speed = 15.0f; // number of pixels the ship will move every frame

    private float xmin, xmax;
    public float playSpacePadding = 0.5f;

    // Use this for initialization
    void Start() {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + playSpacePadding;
        xmax = rightmost.x - playSpacePadding;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        Debug.Log(projectile);
        if (projectile) {
            health -= projectile.GetDamage();
            projectile.Hit();
            Debug.Log(health);
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }



    void Fire() {
        GameObject projectile = Instantiate(weaponType, new Vector3(transform.position.x, transform.position.y + 0.5f, 0), Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
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

        // restrict player to playspace boundaries
        float newX = Mathf.Clamp(tempPos.x, xmin, xmax);
        transform.position = new Vector3(newX, tempPos.y, tempPos.z);
    }
}

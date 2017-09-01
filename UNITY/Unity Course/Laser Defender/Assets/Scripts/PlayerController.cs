using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 15.0f; // number of pixels the ship will move every frame
    public float playSpacePadding = 0.5f;
    public int weaponSlot = 1;

    [Header("Weapon")]
    public GameObject weaponType;
    public float fireRate;

    [Header("Generator")]
    public float power = 10f; // how much power will be generated every "frequency" seconds.
    public float maxPower = 100f;
    public float frequency = 1f; // frequency for generate power
    private float powerAmount = 0f;


    [Header("Protection")]
    public float shieldRegen = 10f; // how much does the shiel regenrate every "frequency" seconds.
    public float shieldMax = 100f;
    public float shieldAmount = 100f;
    public float restartShieldTime = 2f;
    public float armor = 1000f;
    //public GameObject shield;
    private bool isShieldDown = false;

    [Header("Sounds Effects")]
    public AudioClip hurt;
    public AudioClip die;


    private Text textPower;
    private Text textShieldUI;
    private Text textArmor;
    private float xmin, xmax, ymin, ymax;
    private bool canMove = true;

    // Use this for initialization
    void Start() {

        // defining border of player's movements
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 uptmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        Vector3 bottommost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        xmin = leftmost.x + playSpacePadding;
        xmax = rightmost.x - playSpacePadding;
        ymax = uptmost.y - playSpacePadding;
        ymin = bottommost.y + playSpacePadding;


        // start generate power
        InvokeRepeating("GeneratePower", 0.00001f, frequency);

        // Start Shield regenerate
        InvokeRepeating("RegenerateShield", 0.001f, frequency);

        textPower = GameObject.Find("Power").GetComponent<Text>();
        textShieldUI = GameObject.Find("ShieldUI").GetComponent<Text>();
        textArmor = GameObject.Find("Armor").GetComponent<Text>();

        //shield.GetComponent<Animator>().enabled = false;
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
        textPower.text = "Power : " + GetPower().ToString();
        textShieldUI.text = "Shield : " + GetShield().ToString();
        textArmor.text = "Armor : " + GetArmor().ToString();

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile) {
            Hurt(projectile);
            if (armor <= 0) {
                Die();
            }
        }
    }

    public void Hurt(Projectile projectile) {
        if (isShieldDown) {
            armor -= projectile.GetDamage();
        } else {
            LoseShield(projectile.GetDamage());
        }
        AudioSource.PlayClipAtPoint(hurt, transform.position);
        projectile.Hit();
    }

    public void Die() {
        AudioSource.PlayClipAtPoint(die, transform.position);
        CancelInvoke("Fire");
        CancelInvoke("GeneratePower");
        CancelInvoke("RegenerateShield");
        gameObject.GetComponent<Collider2D>().enabled = false;
        canMove = false;
        Invoke("YouLose", 2f);
    }

    private void YouLose() {
        GameObject.FindObjectOfType<LevelManager>().LoadLevel("Win");
        Destroy(gameObject);
    }


    void Fire() {
        // creating projectile

        Projectile projectile = weaponType.GetComponent<Projectile>();

        if (GetPower() >= projectile.GetPowerNeed()) {
            GameObject projectileGO = Instantiate(weaponType, transform.position, Quaternion.identity) as GameObject;
            projectileGO.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectile.GetSpeed(), 0);
            projectile.Shoot();
            projectileGO.GetComponent<SpriteRenderer>().sortingLayerName = "PlayerProjectiles";

            // using power
            UsePower(projectile.GetPowerNeed());
        }
    }

    // ==================================== GENERAL =============================
    void MoveShip() {

        if (canMove) {
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

    public float GetArmor() {
        return armor;
    }
    // --------------------------------------------------------------------


    // =========================== GENERATOR ============================
    //  Generate "power" amount of energy every seconds 
    void GeneratePower() {
        float newAmount = powerAmount + power;
        powerAmount = Mathf.Clamp(newAmount, 0f, maxPower);
    }

    public void UsePower(float amount) {
        powerAmount = Mathf.Clamp((powerAmount - amount), 0f, maxPower);
    }

    public float GetPower() {
        return powerAmount;
    }
    // ------------------------------------------------------------------


    // ================ SHIELD ==============================
    private void RegenerateShield() {
        if ((shieldAmount < shieldMax) && (shieldRegen <= GetPower()) && !isShieldDown) {
            UsePower(shieldRegen);
            shieldAmount = Mathf.Clamp((shieldAmount + shieldRegen), 0f, shieldMax);
        }
    }

    public void LoseShield(float amount) {
        shieldAmount = Mathf.Clamp((shieldAmount - amount), 0f, shieldMax);

        //shield.GetComponent<Animator>().enabled = true;
        //shield.GetComponent<Animator>().Play("Shield");
        if (shieldAmount == 0 && !isShieldDown) {
            ShieldDown();
            //shield.GetComponent<Animator>().enabled = false;
        }
    }

    private void ShieldDown() {
        if (!isShieldDown) {
            isShieldDown = true;
            Invoke("ShieldDown", restartShieldTime);
        } else {
            isShieldDown = false;
        }
    }

    public float GetShield() {
        return shieldAmount;
    }
    // ------------------------------------------------


}

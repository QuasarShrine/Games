using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public AudioClip explosion;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private SpriteRenderer spriteR;
    private bool isBreakable;

    // Use this for initialization
    void Start() {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable) {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D ball) {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable) {
            HandleHits();
        }
    }

    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits) {
            DestroyBrick();
        } else {
            LoadSprites();
        }
    }

    void Puff() {
        Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
    }

    void DestroyBrick() {
        breakableCount--;
        levelManager.BrickDestroyed();
        AudioSource.PlayClipAtPoint(explosion, transform.position);
        GeneratePowerUp();
        Puff();
        Destroy(gameObject);
    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;

        if (spriteIndex < hitSprites.Length && spriteIndex >= 0) {
            if (hitSprites[spriteIndex]) {
                spriteR = this.GetComponents<SpriteRenderer>()[0];
                spriteR.sprite = hitSprites[spriteIndex];
            }
        }
    }
    
    void GeneratePowerUp() {
        int perc = Random.Range(0, 100);
        if (perc <= 20) {
            int perc2 = Random.Range(0, 100);
            if (perc2 <= 50) {
                GameObject PU_PlusSize = Instantiate(Resources.Load("PU_PlusSize")) as GameObject;
                PU_PlusSize.transform.position = gameObject.transform.position;
            } else {
                GameObject PU_MinusSize = Instantiate(Resources.Load("PU_MinusSize")) as GameObject;
                PU_MinusSize.transform.position = gameObject.transform.position;
            }
        }
    }
}
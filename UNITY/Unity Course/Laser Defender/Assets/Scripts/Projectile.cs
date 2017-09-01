using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage = 100f;
    public float speed = 7f;
    public float powerNeed = 5f;
    public float soundVolume = 1f;
    public AudioClip soundEffect;


    public void Shoot() {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position, soundVolume);
    }
    public void Hit() {
        Destroy(gameObject);
    }



    // =============== Getters =========================
    public float GetDamage() {
        return damage;
    }

    public float GetSpeed() {
        return speed;
    }

    public float GetPowerNeed() {
        return powerNeed;
    }

}

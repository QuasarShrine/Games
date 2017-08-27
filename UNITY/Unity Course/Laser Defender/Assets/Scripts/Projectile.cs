using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float damage = 100f;
    public float speed = 7f;
    public AudioClip soundEffect;


    public void Shoot() {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position,2f);
    }

    public float GetDamage() {
        return damage;
    }

    public float GetSpeed() {
        return speed;
    }

    public void Hit() {
        Destroy(gameObject);
    }

}

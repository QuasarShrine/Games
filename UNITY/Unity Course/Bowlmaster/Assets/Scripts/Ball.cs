using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody body;
    public bool isBallLaunched = false;
    public Vector3 launchVelocity;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        body.useGravity = false;
        //Launch(launchVelocity);

    }

    public void Launch(Vector3 velocity) {
        body.useGravity = true;
        isBallLaunched = true;
        body.velocity = velocity;
        audioSource.Play();
    }

}

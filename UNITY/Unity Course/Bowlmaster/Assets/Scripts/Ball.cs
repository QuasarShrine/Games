using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody body;
    private Vector3 initialBallPos;
    private Camera mainCamera;
    private AudioSource audioSource;

    public bool inPlay;
    public bool isBallLaunched = false;
    public Vector3 launchVelocity;


	// Use this for initialization
	void Start () {
        initialBallPos = gameObject.transform.position;
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        body.useGravity = false;
        inPlay = false;
        mainCamera = Camera.main;

    }

    public void Launch(Vector3 velocity) {
        body.useGravity = true;
        isBallLaunched = true;
        inPlay = true;
        body.velocity = velocity;
        audioSource.Play();
    }

    public void Reset() {
        gameObject.transform.position = initialBallPos;
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.useGravity = false;
        isBallLaunched = false;
        inPlay = false;
    }

}

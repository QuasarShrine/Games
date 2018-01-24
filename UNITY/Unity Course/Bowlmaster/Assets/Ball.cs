using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody body;
    public Vector3 launchVelocity;

    private AudioSource audioSource;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        Launch();

    }

    private void Launch() {
        body.velocity = launchVelocity;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {
		
	}
}

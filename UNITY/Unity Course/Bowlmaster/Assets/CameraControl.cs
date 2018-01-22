using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0, 30, -100);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = ball.transform.position + offset;
	}
}

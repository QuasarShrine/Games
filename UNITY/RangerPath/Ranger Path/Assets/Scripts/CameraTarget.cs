using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

  public GameObject target;

	// Use this for initialization
	void Start () {
    if (!target) {
      Debug.LogError("A target GameObject need to be set !");
    }
	}
	
	// Update is called once per frame
	void Update () {
    Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, gameObject.transform.position.z);
    gameObject.transform.position = newPos;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer musicPlayer = null;

	void Awake() {
		if (musicPlayer != null) {
			Destroy(gameObject);
		} else {
			musicPlayer = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}


	// Use this for initialization
	void Start() {
	}
	
	// Update is called once per frame
	void Update() {
		
	}
}

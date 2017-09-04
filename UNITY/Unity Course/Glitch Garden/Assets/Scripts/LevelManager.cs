using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [Header("Splash Screen")]
    [Tooltip("How long, in seconds, does the splash screen have to appear. If '0', then this scene is not a splash screen")]
    public float splashTime;


	public void LoadLevel(string name) {
		SceneManager.LoadScene(name);
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitRequest() {
		Application.Quit();
		if (Application.isWebPlayer) {
			print("Can't quit a WebApplication, so bye bye :) ");
		}
	}

    public void Start() {
        if(splashTime > 0) {
            Invoke("LoadNextLevel", splashTime);
        }
    }

}

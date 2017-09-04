using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    public AudioClip splashScreenClip;
    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip winClip;

    private AudioSource music;

    private static int previousLvl = 0;

    static MusicPlayer musicPlayer = null;

    void Awake() {
        if (musicPlayer != null && musicPlayer != this) {
            Destroy(gameObject);
        } else {
            musicPlayer = this;
            GameObject.DontDestroyOnLoad(gameObject);

            music = GetComponent<AudioSource>();
            OnLevelWasLoaded(SceneManager.GetActiveScene().buildIndex);
            //music.clip = startClip;
            //music.loop = true;
            //music.Play();
        }
    }

    private void OnLevelWasLoaded(int level) {
        Debug.Log("MusicPlayer : loaded level " + level);

        if (music) {
            if (level == 0) {
                music.Stop();
                music.clip = splashScreenClip;
                music.loop = false;
                music.Play();
            }
            if (level == 1 && previousLvl != 2) {
                music.Stop();
                music.clip = startClip;
                music.loop = true;
                music.Play();
            }
            if (level == 1) {
                music.Stop();
                music.clip = startClip;
                music.loop = true;
                music.Play();
            }
            if (level == 3) {
                music.Stop();
                music.clip = gameClip;
                music.loop = true;
                music.Play();
            }
            if (level == 5) {
                music.Stop();
                music.clip = winClip;
                music.loop = true;
                music.volume = 0.05f;
                music.Play();
            }
        }
        previousLvl = level;
    }

}

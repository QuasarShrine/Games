using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }


    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        int level = SceneManager.GetActiveScene().buildIndex;
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        if (thisLevelMusic) {
            audioSource.clip = thisLevelMusic;
            if (level != 0) {
                audioSource.loop = true;
            } else {
                audioSource.loop = false;
            }
            audioSource.Play();
        }
    }

    public void SetVolume(float vol) {
        audioSource.volume = vol;
    }
}

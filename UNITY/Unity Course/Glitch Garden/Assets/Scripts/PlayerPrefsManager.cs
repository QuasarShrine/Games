using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    // === INIT ===
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";


    // ============= VOLUME ===========================
    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master out of range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    //  =========== UNLOCK LEVEL =============
    public static void UnlockLevel(int level) {
        if(level <= SceneManager.sceneCountInBuildSettings - 1) {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        } else {
            Debug.LogError("Error : trying to unlock a unknown level");
        }
    }

    public static bool IsLevelUnlocked(int level) {
        if (level <= SceneManager.sceneCountInBuildSettings - 1) {
            if(PlayerPrefs.HasKey(LEVEL_KEY + level.ToString())) {
                return (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1);
            } else {
                return false;
            }
        } else {
            Debug.LogError("Error : Unknown level build Id");
            return false;
        }
    }

    // =============== DIFFICULTY ====================
    public static void SetDifficulty(float diffLevel) {
        if ((diffLevel <= 3f) && (diffLevel >= 0f)) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diffLevel);
        } else {
            Debug.LogError("Error : Uncorrect difficulty level, must be between 1f and 0f");
        }
    }

    public static float GetDifficulty() {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string MASTER_VOLUME = "master_volume";
    private const string DIFICULTY_KEY = "difficulty";

    private const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume > 0f && volume < 1f)
            PlayerPrefs.SetFloat(MASTER_VOLUME, volume);
        else
            Debug.LogError("Master volume out of range");
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("Level you are trying to unlock in not available");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
            return (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1) ? true : false;

        Debug.LogError("Level: " + level + " is not in the build order");
        return false;
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 0f && difficulty <= 3f)
            PlayerPrefs.SetFloat(DIFICULTY_KEY, difficulty);
        else
            Debug.LogError("Difficulty should be between 0 and 3");
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFICULTY_KEY);
    }
}

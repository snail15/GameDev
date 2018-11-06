using UnityEngine;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        PlayerPrefsManager.UnlockLevel(1);
        bool level1 = PlayerPrefsManager.IsLevelUnlocked(1);
        bool level2 = PlayerPrefsManager.IsLevelUnlocked(2);
        string ans = level1.ToString();
        string ans2 = level2.ToString();
        Debug.Log("Level 1 unlocked: " + ans);

        PlayerPrefsManager.IsLevelUnlocked(2);
        Debug.Log("Level 2 unlocked: " + ans2);

        PlayerPrefsManager.IsLevelUnlocked(3);

        Debug.Log("Volume: " + PlayerPrefsManager.GetMasterVolume().ToString());

        Debug.Log("Game Diff: " + PlayerPrefsManager.GetDifficulty().ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
}

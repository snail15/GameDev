using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{

    public Slider VolumeSlider;
    public Slider DifficultySlider;
    public float DefaultVolume;
    public int DefaultDifficulty;
    private BGMManager _bgmManager;

    // Use this for initialization
    void Start()
    {
        VolumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        _bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
        DifficultySlider.value = PlayerPrefsManager.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        _bgmManager.ChangeVolume(VolumeSlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(VolumeSlider.value);
        PlayerPrefsManager.SetDifficulty(DifficultySlider.value);
        LevelLoader levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        levelLoader.LoadSceneName("StartScreen");
    }

    public void SetToDefault()
    {
        VolumeSlider.value = DefaultVolume;
        DifficultySlider.value = DefaultDifficulty;

    }
}

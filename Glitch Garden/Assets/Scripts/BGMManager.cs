using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{


    private int _sceneIndex;
    private AudioClip _bgm;
    private AudioSource _audioSource;
    [SerializeField] AudioClip[] bgmArray;
    // Use this for initialization
    void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _bgm = bgmArray[_sceneIndex];
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _bgm;
        _audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        _audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeVolume(float newVolume)
    {
        _audioSource.volume = newVolume;
    }
}

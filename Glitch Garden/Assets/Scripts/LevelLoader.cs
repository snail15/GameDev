using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private int _currentSceneIndex;
    // Use this for initialization
    void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

        if (_currentSceneIndex == 0 && SplashManager.isReadyToLoadNextScene)
        {
            if (Input.GetButtonDown("Fire1"))
                LoadNextScene();
        }

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }
}

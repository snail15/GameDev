using UnityEngine;
using UnityEngine.UI;

public class SplashManager : MonoBehaviour
{

    public static bool isReadyToLoadNextScene;

    private Text _loadingText;

    private float _startTime;

    private float _alphaChange = 0.6f;

    private bool _shouldDecrease = true;
    // Use this for initialization
    void Start()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        isReadyToLoadNextScene = false;
        _loadingText = GameObject.Find("Loading").GetComponent<Text>();
        _startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - _startTime;

        if (elapsedTime < 7f)
        {
            BlinkText("Loading...");
        }
        else
        {
            BlinkText("Ready, Click Anywhere to Start!");
            isReadyToLoadNextScene = true;
        }

    }

    private void BlinkText(string text)
    {
        _loadingText.text = text;

        //Can directly assign value to a, so you need temporary variable
        var newAlpha = _loadingText.color;

        if (_shouldDecrease)
        {
            newAlpha.a = _loadingText.color.a - _alphaChange * Time.deltaTime;
            _loadingText.color = newAlpha;
            if (newAlpha.a < 0)
                _shouldDecrease = false;
        }

        if (!_shouldDecrease)
        {
            newAlpha.a = _loadingText.color.a + _alphaChange * Time.deltaTime;
            _loadingText.color = newAlpha;
            if (newAlpha.a > 1f)
                _shouldDecrease = true;
        }
    }
}

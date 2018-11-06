using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{


    [SerializeField] private float fadeInTime;

    private Image _fadePanel;

    private Color _currentColor = Color.black;

    // Use this for initialization
    void Start()
    {
        _fadePanel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChangeRate = Time.deltaTime / fadeInTime;
            _currentColor.a -= alphaChangeRate;
            _fadePanel.color = _currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

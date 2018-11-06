using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnityEvent onReset;
    public static GameManager instance;

    public GameObject readyPanel;
    public Text scoreText;
    public Text bestScoreText;
    public Text messageText;

    public bool isRoundActive = false;
    private int _score;

    public CanonPivotController canonPivoController;
    public CamFollow cam;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int newScore)
    {
        _score += newScore;
        UpdateBestScore();
    }

    void UpdateBestScore()
    {
        if (GetBestScore() < _score)
            PlayerPrefs.SetInt("BestScore", _score);
    }

    private int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + _score;
        bestScoreText.text = "Best Score: " + GetBestScore();
    }

    public void OnBallDestroy()
    {
        UpdateUI();
        isRoundActive = false;
    }

    public void Reset()
    {
        _score = 0;
        UpdateUI();
        StartCoroutine("RoundRoutine");
    }

    IEnumerator RoundRoutine()
    {

        onReset.Invoke();

        readyPanel.SetActive(true);
        cam.SetTarget(canonPivoController.transform, CamFollow.State.Idle);
        canonPivoController.enabled = false;

        isRoundActive = false;

        messageText.text = "Ready!";

        yield return new WaitForSeconds(3f);

        isRoundActive = true;
        readyPanel.SetActive(false);
        canonPivoController.enabled = true;
        cam.SetTarget(canonPivoController.transform, CamFollow.State.Ready);

        while (isRoundActive)
        {
            yield return null;
        }

        readyPanel.SetActive(true);
        canonPivoController.enabled = false;

        UpdateUI();
        messageText.text = "Round Finished";

        yield return new WaitForSeconds(3f);
        Reset();
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine("RoundRoutine");
    }

    // Update is called once per frame
    void Update()
    {

    }
}

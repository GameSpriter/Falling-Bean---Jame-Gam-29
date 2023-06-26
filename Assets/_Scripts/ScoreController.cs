using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Singleton;

    [SerializeField]
    private int LevelCompleteScore;
    private int Score = 0;
    [SerializeField]
    private TMPro.TMP_Text TMPScoreText;

    private void Awake()
    {
        Singleton = this;

        UpdateScore();
    }

    public void AddScore(int value)
    {
        Score += value;
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (!TMPScoreText) return;
        TMPScoreText.text = "" + Score + " / " + LevelCompleteScore;
    }
}

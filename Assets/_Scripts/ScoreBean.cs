using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBean : MonoBehaviour
{
    private int Score = 0;
    [SerializeField]
    private TMPro.TMP_Text TMPScoreText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Bean")) return;

        Destroy(other.gameObject);

        Score += other.gameObject.GetComponent<Bean>().BeanScriptableObject.Score;
        UpdateScore();
    }

    public void UpdateScore() {
        if (!TMPScoreText) return;
        TMPScoreText.text = "" + Score;
    }
}

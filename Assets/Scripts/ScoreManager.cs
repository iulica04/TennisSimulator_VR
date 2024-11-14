using UnityEngine;
using TMPro; // Asigură-te că importi biblioteca TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText; // Referință la TextMeshProUGUI

    void Start()
    {
        UpdateScoreText();
    }

    public void UpdateScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
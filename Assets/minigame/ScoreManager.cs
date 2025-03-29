using UnityEngine;
using TMPro; // Required for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public int score = 0;  // The player's current score
    public TextMeshProUGUI scoreText;  // TextMeshPro component to display the score

    public void IncreaseScore()
    {
        score++;  // Increase score by 1
        scoreText.text = "Score: " + score.ToString();  // Update the score display
    }
}

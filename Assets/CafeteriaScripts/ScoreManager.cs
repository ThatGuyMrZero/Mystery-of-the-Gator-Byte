using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private float startTime;
    public float difficultyMultiplier = 1f;
    public float scoreDelay = 3f;
    public int totalScore = 0;

    public void StartOrderScoring()
    {
        startTime = Time.time;
    }

    public void CompleteOrderScoring()
    {
        float elapsedTime = Time.time - startTime;
        float baseScore = 100f;

        if (elapsedTime > scoreDelay)
        {
            baseScore -= (elapsedTime - scoreDelay) * 5f;
        }

        baseScore = Mathf.Max(baseScore, 20);
        float orderScore = baseScore * difficultyMultiplier;
        totalScore += Mathf.RoundToInt(orderScore);

        Debug.Log($"Order completed in {elapsedTime} seconds");
        Debug.Log($"Score is {orderScore}");

        StartOrderScoring();
    }
}

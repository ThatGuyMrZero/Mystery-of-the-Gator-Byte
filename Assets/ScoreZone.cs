using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public string acceptedType; // "string", "int", or "bool"
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        FallingData data = other.GetComponent<FallingData>();

        if (data != null && data.dataType == acceptedType)
        {
            score++;
            Debug.Log("Entered ScoreZone with: " + other.name);

            Debug.Log($"{acceptedType} Box Score: {score}");

            Destroy(other.gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }
}

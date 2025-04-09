using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public string acceptedType; // "string", "int", or "bool"

    private int score = 0;

    [Header("Score Effect Settings")]
    public GameObject scoreEffectPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        FallingData data = other.GetComponent<FallingData>();

        if (data != null && data.dataType == acceptedType)
        {
            score++;
            Debug.Log("Entered ScoreZone with: " + other.name);
            Debug.Log($"{acceptedType} Box Score: {score}");

            // 🟡 Instantiate score effect
            if (scoreEffectPrefab != null)
            {
                GameObject effect = Instantiate(scoreEffectPrefab, transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }
}

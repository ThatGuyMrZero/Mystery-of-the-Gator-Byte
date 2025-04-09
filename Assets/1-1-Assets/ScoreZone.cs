using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public string acceptedType; // "string", "int", or "bool"

    private int score = 0;

    [Header("Score Effect Settings")]
    public GameObject scoreEffectPrefab;
    public GameObject scoreEffectPrefab2;
    public GameObject scoreEffectPrefab3;
    public float effectDuration = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        FallingData data = other.GetComponent<FallingData>();

        if (data != null && data.dataType == acceptedType)
        {
            score++;
            Debug.Log("Entered ScoreZone with: " + other.name);
            Debug.Log($"{acceptedType} Box Score: {score}");

            // 🟡 Instantiate first score effect (if assigned)
            if (scoreEffectPrefab != null)
            {
                GameObject effect1 = Instantiate(scoreEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect1, effectDuration);
            }

            // 🟡 Instantiate second score effect (if assigned)
            if (scoreEffectPrefab2 != null)
            {
                GameObject effect2 = Instantiate(scoreEffectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, effectDuration);
            }

            if (scoreEffectPrefab3 != null)
            {
                GameObject effect3 = Instantiate(scoreEffectPrefab3, transform.position, Quaternion.identity);
                Destroy(effect3, effectDuration);
            }

            Destroy(other.gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }
}

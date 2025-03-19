using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public GameObject[] dataBoxes;  // The 3 data type boxes (string, int, bool)
    public GameObject fallingDataPrefab; // The falling data prefab
    public GameObject[] dataTextSprites;  // Array of 8 empty GameObjects to assign in the inspector
    public float spawnRate = 2f;  // Time interval between asset spawns
    private int score = 0;  // The player's score

    // UI Text for the score (can take an empty GameObject as well)
    public Text scoreText;  // UI Text to display the score, can be null (empty) or missing
    public SpriteRenderer scoreSprite;  // Can take an empty sprite for score feedback

    private void Start()
    {
        // Start spawning falling data
        InvokeRepeating("SpawnFallingData", 0f, spawnRate);
    }

    private void SpawnFallingData()
    {
        // Debug log to check if fallingDataPrefab is assigned
        if (fallingDataPrefab == null)
        {
            Debug.LogError("fallingDataPrefab is not assigned in the Inspector!");
            return;
        }

        // Spawn the falling data at a random X position and above the screen
        float spawnX = Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(spawnX, 6f, 0f);

        GameObject newData = Instantiate(fallingDataPrefab, spawnPosition, Quaternion.identity);

        // Debug log to check if the prefab contains the FallingData script
        FallingData fallingDataScript = newData.GetComponent<FallingData>();
        if (fallingDataScript == null)
        {
            Debug.LogError("FallingData script is not attached to the prefab!");
            return;
        }

        // Pass the dataTextSprites to the FallingData component
        fallingDataScript.dataText = dataTextSprites;

        // Debug log to ensure dataTextSprites is assigned
        if (dataTextSprites == null || dataTextSprites.Length == 0)
        {
            Debug.LogError("dataTextSprites is not assigned or is empty!");
            return;
        }
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        // Check if scoreText is assigned and update it
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the score UI
        }
        else
        {
            Debug.LogWarning("scoreText is not assigned in the inspector.");
        }

        // Check if scoreSprite is assigned and update it (optional)
        if (scoreSprite != null)
        {
            // You can add feedback here for the sprite (e.g., changing color on score update)
            scoreSprite.color = Color.green;  // Just an example of sprite feedback
        }
        else
        {
            Debug.LogWarning("scoreSprite is not assigned in the inspector.");
        }
    }
}

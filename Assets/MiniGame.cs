using UnityEngine;
using TMPro;

public class MiniGame : MonoBehaviour
{
    [Header("Falling Data Settings")]
    public GameObject[] dataTextPrefabs;
    public float spawnInterval = 2f;
    public float minX = -5f;
    public float maxX = 5f;
    public float spawnY = 12f;

    [Header("Score Zones")]
    public ScoreZone stringBox;
    public ScoreZone intBox;
    public ScoreZone boolBox;

    [Header("World-Space Score Text (TextMeshPro)")]
    public TextMeshPro stringScore;
    public TextMeshPro intScore;
    public TextMeshPro boolScore;

    private int currentIndex = 0;
    private bool isSpawning = false;

    void Update()
    {
        UpdateScoreUI();
    }

    public void StartMiniGame()
    {
        Debug.Log("🚀 StartMiniGame() was called!");

        if (!isSpawning && dataTextPrefabs.Length > 0)
        {
            InvokeRepeating(nameof(SpawnText), 0f, spawnInterval);
            isSpawning = true;
            Debug.Log("✅ MiniGame is now spawning text.");
        }
    }

    public void StopMiniGame()
    {
        CancelInvoke(nameof(SpawnText));
        isSpawning = false;
        Debug.Log("⛔ MiniGame stopped.");
        ShowScores();
    }

    void SpawnText()
    {
        if (dataTextPrefabs.Length == 0) return;

        GameObject prefabToSpawn = dataTextPrefabs[currentIndex];

        float spawnX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        currentIndex = (currentIndex + 1) % dataTextPrefabs.Length;
    }

    void UpdateScoreUI()
    {
        if (stringScore != null && stringBox != null)
            stringScore.text = $"String: {stringBox.GetScore()}";

        if (intScore != null && intBox != null)
            intScore.text = $"Int: {intBox.GetScore()}";

        if (boolScore != null && boolBox != null)
            boolScore.text = $"Bool: {boolBox.GetScore()}";
    }

    public void ShowScores()
    {
        Debug.Log("📊 Final Scores:");
        if (stringBox != null) Debug.Log($"String Score: {stringBox.GetScore()}");
        if (intBox != null) Debug.Log($"Int Score: {intBox.GetScore()}");
        if (boolBox != null) Debug.Log($"Bool Score: {boolBox.GetScore()}");
    }
}

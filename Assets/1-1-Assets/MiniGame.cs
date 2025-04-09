using UnityEngine;
using TMPro;

public class MiniGame : MonoBehaviour
{
    // ~~~~~ Falling Data ~~~~~~ // 
    [Header("Falling Data Settings")]
    public GameObject[] dataTextPrefabs;
    public float spawnInterval = 2f;
    public float minX = -5f;
    public float maxX = 5f;
    public float spawnY = 12f;

    // ~~~~~ Score System ~~~~~~ // 
    [Header("Score Zones")]
    public ScoreZone stringBox;
    public ScoreZone intBox;
    public ScoreZone boolBox;

    // ~~~~~ UI Fields for Scores ~~~~~~ // 
    [Header("World-Space Score Text (TextMeshPro)")]
    public TextMeshPro stringScore;
    public TextMeshPro intScore;
    public TextMeshPro boolScore;
    public TextMeshPro totalScore;

    private int currentIndex = 0; //tracks which prefab to spawn next, cycle through the array when at the end
    private bool isSpawning = false; // tracks if text is spawning 

    [Header("Win Screen")]
    public GameObject winPopup; // Assign in the Inspector and make sure it's deactivated by default


    private bool hasPlayerWon = false; 

    bool CheckTotalWinCondition()
    {
        int total = 0;

        if (stringBox != null) total += stringBox.GetScore();
        if (intBox != null) total += intBox.GetScore();
        if (boolBox != null) total += boolBox.GetScore();

        return total >= 8;
    }

    void HandleWin()
    {
        Debug.Log("🎉 Player reached total score of 8! MiniGame won.");

        StopMiniGame(); // stop further spawns

        if (winPopup != null)
            winPopup.SetActive(true); // show win screen
    }

    void Update()
    {
        UpdateScoreUI();

        if (!hasPlayerWon && CheckTotalWinCondition())
        {
            hasPlayerWon = true;
            HandleWin();
        }
    }

    public void StartMiniGame()
    {
        Debug.Log("🚀 StartMiniGame() was called!");
        Debug.Log($"🌟 Player win status: {hasPlayerWon}");

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

        int total = 0;

        if (stringBox != null) total += stringBox.GetScore();
        if (intBox != null) total += intBox.GetScore();
        if (boolBox != null) total += boolBox.GetScore();

        if (totalScore != null)
            totalScore.text = $"Total: {total}";
    }

    public void ShowScores()
    {
        Debug.Log("📊 Final Scores:");

        int stringScoreValue = stringBox != null ? stringBox.GetScore() : 0;
        int intScoreValue = intBox != null ? intBox.GetScore() : 0;
        int boolScoreValue = boolBox != null ? boolBox.GetScore() : 0;

        int total = stringScoreValue + intScoreValue + boolScoreValue;

        Debug.Log($"🟪 String Score: {stringScoreValue}");
        Debug.Log($"🟦 Int Score: {intScoreValue}");
        Debug.Log($"🟩 Bool Score: {boolScoreValue}");
        Debug.Log($"🧮 Total Score: {total}");
    }

}

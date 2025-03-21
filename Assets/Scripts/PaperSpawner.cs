using UnityEngine;

public class PaperSpawner : MonoBehaviour
{
    public GameObject paperPrefab;
    public Transform spawnPoint;

    [Header("Settings")]
    public int numberOfPapers = 10;

    private int spawnedCount = 0;

    void Start()
    {
        SpawnPapers();
    }

    void SpawnPapers()
    {
        for (int i = 0; i < numberOfPapers; i++)
        {
            SpawnPaper();
        }
    }

    void SpawnPaper()
    {
        if (spawnedCount >= numberOfPapers) return;

        Vector3 spawnPos = spawnPoint.position + new Vector3(0, 0.1f * spawnedCount, 0);
        GameObject paper = Instantiate(paperPrefab, spawnPos, Quaternion.identity);

        Paper paperScript = paper.GetComponent<Paper>();
        paperScript.grade = Random.Range(30, 100);
        paperScript.UpdateGradeVisual();

        spawnedCount++;
    }
}

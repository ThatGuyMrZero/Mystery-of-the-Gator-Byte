using UnityEngine;

public class PaperSpawner : MonoBehaviour
{
    public GameObject paperPrefab;
    public RectTransform spawnPoint;
    public RectTransform canvasTransform;

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

        float zOffset = -0.1f * spawnedCount;
        Vector3 spawnPos = spawnPoint.position + new Vector3(0, 0, zOffset);

        GameObject paper = Instantiate(paperPrefab, spawnPos, Quaternion.identity, canvasTransform);

        paper.tag = "Paper";

        Paper paperScript = paper.GetComponent<Paper>();
        paperScript.grade = Random.Range(30, 100);
        paperScript.UpdateGradeVisual();

        spawnedCount++;
    }

    public void ResetBoard()
    {
        Debug.Log("ResetBoard called. Checking children of canvasTransform...");

        foreach (Transform child in canvasTransform)
        {
            Debug.Log("Found child: " + child.name + " with tag: " + child.tag);

            if (child.CompareTag("Paper"))
            {
                Debug.Log("Destroying " + child.name);
                Destroy(child.gameObject);
            }
        }

        spawnedCount = 0;
        SpawnPapers();
    }

}

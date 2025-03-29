using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] dataTextPrefabs; // Your array of "string", "int", "bool" prefabs
    public float spawnInterval = 2f;
    public float minX = -5f;
    public float maxX = 5f;
    public float spawnY = 6f;

    private int currentIndex = 0;
    private bool isSpawningActive = false;

    void Start()
    {
        CancelInvoke("SpawnObject");
    }

    public void ActivateSpawner()
    {
        if (!isSpawningActive && dataTextPrefabs.Length > 0)
        {
            InvokeRepeating("SpawnObject", 0f, spawnInterval);
            isSpawningActive = true;
            Debug.Log("Spawner Activated");
        }
    }

    public void DeactivateSpawner()
    {
        if (isSpawningActive)
        {
            CancelInvoke("SpawnObject");
            isSpawningActive = false;
            Debug.Log("Spawner Deactivated");
        }
    }

    void SpawnObject()
    {
        if (dataTextPrefabs.Length == 0) return;

        // Use prefab in order
        GameObject prefabToSpawn = dataTextPrefabs[currentIndex];

        // Set random spawn position
        float spawnX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Move to next prefab, loop if at the end
        currentIndex = (currentIndex + 1) % dataTextPrefabs.Length;
    }
}

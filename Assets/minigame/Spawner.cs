using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject dataPrefab;  // The prefab for the falling data objects
    public Transform spawnArea;    // The area where assets will spawn (position reference)
    public float spawnInterval = 2f; // How frequently new data objects will spawn

    void Start()
    {
        // Start spawning data at intervals
        InvokeRepeating("SpawnData", 0f, spawnInterval);
    }

    void SpawnData()
    {
        // Ensure dataPrefab is assigned before instantiating
        if (dataPrefab != null)
        {
            // Randomize spawn position along the X-axis
            float spawnX = Random.Range(-5f, 5f);
            Vector3 spawnPosition = new Vector3(spawnX, spawnArea.position.y, 0); // Set spawn position using spawnArea's Y position

            // Instantiate the falling data object at the spawn position
            Instantiate(dataPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Data prefab is missing. Cannot instantiate.");
        }
    }
}

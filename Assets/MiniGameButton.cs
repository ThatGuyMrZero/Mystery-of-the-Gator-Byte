using UnityEngine;

public class MiniGameButton : MonoBehaviour
{
    public Spawner spawner;

    public void StartSpawning()
    {
        if (spawner != null)
        {
            spawner.ActivateSpawner();
        }
        else
        {
            Debug.LogWarning("Spawner reference not set!");
        }
    }

    public void StopSpawning()
    {
        if (spawner != null)
        {
            spawner.DeactivateSpawner();
        }
        else
        {
            Debug.LogWarning("Spawner reference not set!");
        }
    }
}

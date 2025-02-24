using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public LevelManager levelManager;
    public string targetLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // If the player enters the trigger
        {
            // Debug message to confirm the trigger is being activated
            Debug.Log("Player entered the trigger zone");

            // Transition to the specified level and activate the corresponding objects
            levelManager.SetActiveLevel(targetLevel);
        }
    }
}

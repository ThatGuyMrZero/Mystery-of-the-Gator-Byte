using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Level 1 Objects
    public GameObject level1Object1;
    public GameObject level1Object2;
    public GameObject level1Object3;

    // Level 2 Objects
    public GameObject level2Object1;
    public GameObject level2Object2;
    public GameObject level2Object3;

    // Level 3 Objects
    public GameObject level3Object1;
    public GameObject level3Object2;
    public GameObject level3Object3;

    // Level 4 Objects
    public GameObject level4Object1;
    public GameObject level4Object2;
    public GameObject level4Object3;

    void Start()
    {
        // Initially, activate only Level 1 objects
        SetActiveLevel("Level1");
    }

    // Method to switch between levels based on level name
    public void SetActiveLevel(string levelName)
    {
        // Deactivate all level objects first
        DeactivateAllObjects();

        // Activate objects for the chosen level
        if (levelName == "Level1")
        {
            level1Object1.SetActive(true);
            level1Object2.SetActive(true);
            level1Object3.SetActive(true);
        }
        else if (levelName == "Level2")
        {
            level2Object1.SetActive(true);
            level2Object2.SetActive(true);
            level2Object3.SetActive(true);
        }
        else if (levelName == "Level3")
        {
            level3Object1.SetActive(true);
            level3Object2.SetActive(true);
            level3Object3.SetActive(true);
        }
        else if (levelName == "Level4")
        {
            level4Object1.SetActive(true);
            level4Object2.SetActive(true);
            level4Object3.SetActive(true);
        }
    }

    // Method to deactivate all level objects
    private void DeactivateAllObjects()
    {
        level1Object1.SetActive(false);
        level1Object2.SetActive(false);
        level1Object3.SetActive(false);
        
        level2Object1.SetActive(false);
        level2Object2.SetActive(false);
        level2Object3.SetActive(false);
        
        level3Object1.SetActive(false);
        level3Object2.SetActive(false);
        level3Object3.SetActive(false);
        
        level4Object1.SetActive(false);
        level4Object2.SetActive(false);
        level4Object3.SetActive(false);
    }
}

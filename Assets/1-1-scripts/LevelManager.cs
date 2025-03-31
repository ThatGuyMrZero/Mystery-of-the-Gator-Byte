using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject level0Object1;
    public GameObject level0Object2;
    public GameObject level1Object1;
    public GameObject level1Object2;
    public GameObject level1Object3;

    // Level 2 Objects
    public GameObject level2Object1;
    public GameObject level2Object2;

    // Level 3a Objects
    public GameObject level3aObject1;
    public GameObject level3aObject2;
    public GameObject level3aObject3;
    
    // Level 3b Objects
    public GameObject level3bObject1;
    public GameObject level3bObject2;
    public GameObject level3bObject3;

    // Level 4 Objects
    public GameObject level4Object1;
    public GameObject level4Object2;
    public GameObject level4Object3;

    void Start()
    {
        // Initially, activate only Level 0 objects
        SetActiveLevel("Level0");
    }

    // Method to switch between levels based on level name
    public void SetActiveLevel(string levelName)
    {
        // Deactivate all level objects first
        DeactivateAllObjects();

        if (levelName == "Level0")
        {
            if (level0Object1 != null) level0Object1.SetActive(true);
            if (level0Object2 != null) level0Object2.SetActive(true);

        }
        else if (levelName == "Level1")
        {
            if (level1Object1 != null) level1Object1.SetActive(true);
            if (level1Object2 != null) level1Object2.SetActive(true);
            if (level1Object3 != null) level1Object3.SetActive(true);
        }
        else if (levelName == "Level2")
        {
            if (level2Object1 != null) level2Object1.SetActive(true);
            if (level2Object2 != null) level2Object2.SetActive(true);
        }
        else if (levelName == "Level3a")
        {
            if (level3aObject1 != null) level3aObject1.SetActive(true);
            if (level3aObject2 != null) level3aObject2.SetActive(true);
            if (level3aObject3 != null) level3aObject3.SetActive(true);
        }
        else if (levelName == "Level3b")
        {
            if (level3bObject1 != null) level3bObject1.SetActive(true);
            if (level3bObject2 != null) level3bObject2.SetActive(true);
            if (level3bObject3 != null) level3bObject3.SetActive(true);
        }
        else if (levelName == "Level4")
        {
            if (level4Object1 != null) level4Object1.SetActive(true);
            if (level4Object2 != null) level4Object2.SetActive(true);
            if (level4Object3 != null) level4Object3.SetActive(true);
        }
    }

    // Method to deactivate all level objects
    private void DeactivateAllObjects()
    {
        // Deactivate all level objects, but only if they are assigned (non-null)
        if (level0Object1 != null) level0Object1.SetActive(false);
        if (level0Object2 != null) level0Object2.SetActive(false);

        if (level1Object1 != null) level1Object1.SetActive(false);
        if (level1Object2 != null) level1Object2.SetActive(false);
        if (level1Object3 != null) level1Object3.SetActive(false);
        
        if (level2Object1 != null) level2Object1.SetActive(false);
        if (level2Object2 != null) level2Object2.SetActive(false);
        
        if (level3aObject1 != null) level3aObject1.SetActive(false);
        if (level3aObject2 != null) level3aObject2.SetActive(false);
        if (level3aObject3 != null) level3aObject3.SetActive(false);

        if (level3bObject1 != null) level3bObject1.SetActive(false);
        if (level3bObject2 != null) level3bObject2.SetActive(false);
        if (level3bObject3 != null) level3bObject3.SetActive(false);
        
        if (level4Object1 != null) level4Object1.SetActive(false);
        if (level4Object2 != null) level4Object2.SetActive(false);
        if (level4Object3 != null) level4Object3.SetActive(false);
    }
}

using UnityEngine;
using TMPro; // Required for TextMeshPro

public class DataManager : MonoBehaviour
{
    public string assetType;  // Can be string, int, or bool
    private TextMeshPro textMeshPro; // TextMeshPro component for displaying text

    void Start()
    {
        // Randomly assign a data type (for demonstration purposes)
        int rand = Random.Range(0, 3);
        if (rand == 0)
            assetType = "string";
        else if (rand == 1)
            assetType = "int";
        else
            assetType = "bool";

        // Get the TextMeshPro component attached to this GameObject
        textMeshPro = GetComponent<TextMeshPro>();

        // Check if the TextMeshPro component exists, then set the text
        if (textMeshPro != null)
        {
            textMeshPro.text = assetType;
        }
        else
        {
            Debug.LogWarning("TextMeshPro component not found on this GameObject.");
        }
    }

    void Update()
    {
        // Make the asset fall
        transform.Translate(Vector3.down * Time.deltaTime * 100f);

        // If the asset falls below the screen, destroy it
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}

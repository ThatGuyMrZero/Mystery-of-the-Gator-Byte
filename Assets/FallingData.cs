public class FallingData : MonoBehaviour
{
    public GameObject[] dataText; // Array of GameObject references (empty assets) for text
    public float fallSpeed = 3f; // Speed at which the object falls

    private GameObject currentDataObject; // The current text asset to fall
    private string dataType; // Will store the type of data: "string", "int", or "bool"

    // Spawn area boundaries
    public float minX = -5f; // Minimum X position
    public float maxX = 5f;  // Maximum X position
    public float spawnY = 6f; // Y position (fixed for spawn area)

    private void Start()
    {
        if (dataText == null || dataText.Length == 0)
        {
            Debug.LogError("Data text array is not assigned or is empty!");
            return;
        }

        // Randomly select a text asset from the dataText array
        int randomIndex = Random.Range(0, dataText.Length);

        // Ensure the selected dataText is valid
        if (dataText[randomIndex] != null)
        {
            currentDataObject = Instantiate(dataText[randomIndex], transform.position, Quaternion.identity);
            dataType = currentDataObject.name; // Assume that the name of the GameObject matches the data type
        }
        else
        {
            Debug.LogWarning("Selected dataText asset is null.");
        }

        // Set the spawn position within the specified range
        float spawnX = Random.Range(minX, maxX); // Random X within the minX and maxX range
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f); // Set Y position to the fixed spawnY value

        // Update the instantiated object's position
        currentDataObject.transform.position = spawnPosition;
    }

    private void Update()
    {
        // Make the object fall down
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy the object if it goes out of view
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the asset falls into the correct box based on its dataType
        if (other.CompareTag("StringBox") && dataType == "string" ||
            other.CompareTag("IntBox") && dataType == "int" ||
            other.CompareTag("BoolBox") && dataType == "bool")
        {
            // Use the updated method to find the object
            MiniGame miniGame = Object.FindFirstObjectByType<MiniGame>();
            
            if (miniGame != null)
            {
                miniGame.IncreaseScore();
            }
            else
            {
                Debug.LogWarning("MiniGame instance not found!");
            }

            Destroy(gameObject);
        }
    }
}

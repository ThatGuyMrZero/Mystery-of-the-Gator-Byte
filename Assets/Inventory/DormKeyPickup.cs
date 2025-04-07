using UnityEngine;
using UnityEngine.SceneManagement;

public class DormKeyPickup : MonoBehaviour
{
    public string sceneToLoad = "FinalScene"; // Set this in the Inspector

    void OnMouseDown()
    {
        Debug.Log("🔑 Key clicked! Loading final scene...");
        SceneManager.LoadScene(sceneToLoad);
    }
}

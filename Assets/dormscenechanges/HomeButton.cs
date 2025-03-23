using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public string homeScene = "1-1"; 

    private void OnMouseDown()
    {
        Debug.Log("Going home...");
        SceneManager.LoadScene(homeScene);
    }
}

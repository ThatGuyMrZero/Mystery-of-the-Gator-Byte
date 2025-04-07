using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("1-1"); // change to match your first scene’s exact name
    }
}

using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}

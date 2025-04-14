using UnityEngine;

public class ClickableQuit : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorClickHandler : MonoBehaviour
{
    public GameObject popUpPanel; // Assign a pop-up panel if you change your mind later

    private void OnMouseDown()
    {
        Debug.Log("Door Clicked!"); // Debugging to confirm it works
        ShowDoorOptions();
    }

    void ShowDoorOptions()
    {
        // Show a simple pop-up in the Debug Log for now
        Debug.Log("1. Go to Library (Press L) | 2. Go to Dorm (Press D)");

        // Later: You can replace this with a custom pop-up if needed
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("LibraryScene");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene("DormScene");
        }
    }
}

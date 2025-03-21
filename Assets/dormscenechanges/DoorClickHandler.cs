using UnityEngine;

public class DoorClickHandler : MonoBehaviour
{
    public GameObject popUpMenu; // Assign the pop-up in the Inspector

    private void OnMouseDown()
    {
        if (popUpMenu != null)
        {
            popUpMenu.SetActive(true); // Show pop-up when the door is clicked
        }
    }
}

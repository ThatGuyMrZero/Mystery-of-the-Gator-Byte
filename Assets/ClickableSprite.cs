using UnityEngine;

public class ClickableSprite : MonoBehaviour
{
    public GameObject chalkboard; // Reference to the chalkboard

    void OnMouseDown()
    {
        // Only allow clicks if the chalkboard is NOT active
        if (chalkboard != null && !chalkboard.activeSelf)
        {
            chalkboard.SetActive(true);
        }
    }
}

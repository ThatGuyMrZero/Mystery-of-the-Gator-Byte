using UnityEngine;

public class ClickableSprite : MonoBehaviour
{
    public GameObject chalkboard; // Reference to the chalkboard sprite

    void OnMouseDown()
    {
        if (chalkboard != null)
        {
            bool isActive = chalkboard.activeSelf;
            chalkboard.SetActive(!isActive); // Toggle chalkboard visibility
        }
    }
}

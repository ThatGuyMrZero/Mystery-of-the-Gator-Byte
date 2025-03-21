using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public GameObject chalkboard; // Reference to the chalkboard

    void OnMouseDown()
    {
        if (chalkboard != null)
        {
            chalkboard.SetActive(false); // Hide the chalkboard when X is clicked
        }
    }

    void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}

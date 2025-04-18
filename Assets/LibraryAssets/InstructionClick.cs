using UnityEngine;

public class InstructionClick : MonoBehaviour
{
    private Collider2D col;

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        gameObject.SetActive(false);

        if (col != null)
        {
            col.enabled = false; // Disable collider to prevent interference later
        }
    }
}

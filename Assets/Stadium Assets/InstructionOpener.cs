using UnityEngine;

public class InstructionOpener : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector3 origScale;
    private bool isOpen = false;

    public WinConditionManager wcm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        wcm = FindAnyObjectByType<WinConditionManager>();
        origScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        transform.localScale = origScale * 1.1f;
    }

    private void OnMouseExit()
    {
        transform.localScale = origScale;
    }

    private void OnMouseDown()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Showing minigame instructions...");
            wcm.DisableCurrentPhase();
        }
        else
        {
            isOpen = false;
            Debug.Log("Closing minigame instructions...");
            wcm.ReenableCurrentPhase();
        }
    }
}

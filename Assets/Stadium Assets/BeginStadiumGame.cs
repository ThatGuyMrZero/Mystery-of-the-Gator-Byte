using UnityEngine;

public class BeginStadiumGame : MonoBehaviour
{
    private SpriteRenderer sr;
    private Vector3 origScale;

    public WinConditionManager wcm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
        Debug.Log("Let the game begin!");
        wcm.StartGame();
    }
}

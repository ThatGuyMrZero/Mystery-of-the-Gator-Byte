using UnityEngine;

public class HelmetClick : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color origColor;
    private Vector3 origScale;

    public GameController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        origColor = sr.color;
        origScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        sr.color = Color.green;
        transform.localScale = origScale * 1.1f;
    }

    private void OnMouseExit()
    {
        sr.color = origColor;
        transform.localScale = origScale;
    }

    private void OnMouseDown()
    {
        Debug.Log("Helmet clicked!");
        controller.HelmetClicked();
    }
}

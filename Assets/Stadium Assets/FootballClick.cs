using UnityEngine;

public class FootballClick : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color origColor;
    private Vector3 origScale;

    public GameController controller;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        origColor = sr.color;
        origScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        sr.color = Color.yellow;
        transform.localScale = origScale * 1.1f;
    }

    private void OnMouseExit()
    {
        sr.color = origColor;
        transform.localScale = origScale;
    }

    private void OnMouseDown()
    {
        controller.StartMinigame();
    }
}

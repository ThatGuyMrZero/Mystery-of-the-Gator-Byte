using UnityEngine;

public class SpriteZoom : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 zoomedScale;
    private bool isZoomed = false;
    private Vector3 originalPosition;
    private Vector3 zoomedPosition;

    private SpriteRenderer sr;
    public Color highlightColor = new Color(1f, 0.95f, 0.6f); // Soft highlight (warm yellowish)
    private Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;

        // Grows ~1.8x original size
        zoomedScale = originalScale * 3.0f;

        originalPosition = transform.position;

        // Nudges it toward center, but not full-screen
        zoomedPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10));

        originalColor = sr.color;

        // Highlight before it's clicked
        sr.material = new Material(Shader.Find("Sprites/Default"));
        sr.color = highlightColor;
    }

    void OnMouseDown()
    {
        if (!isZoomed)
        {
            transform.localScale = zoomedScale;
            transform.position = zoomedPosition;
            sr.color = Color.white; // Remove highlight when zoomed
            isZoomed = true;
        }
        else
        {
            transform.localScale = originalScale;
            transform.position = originalPosition;
            sr.color = highlightColor; // Reapply highlight
            isZoomed = false;
        }
    }
}

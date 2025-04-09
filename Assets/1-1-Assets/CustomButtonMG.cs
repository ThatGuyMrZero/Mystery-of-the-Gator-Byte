using UnityEngine;

public class CustomButtonMG : MonoBehaviour
{
    public MiniGame miniGame;            // Reference to MiniGame script
    public GameObject startButton;       // Start button GameObject to hide
    public GameObject stopButton;        // Stop button GameObject to show
    public GameObject textBox;           // Text box GameObject to hide
    public bool isStartButton = true;    // True = start, False = stop

    private SpriteRenderer spriteRenderer;

    public Color hoverColor = new Color(0f, 0.129f, 0.647f); // Light blue
    public Color clickColor = new Color(1f, 1f, 1f);         // White
    public Color defaultColor = Color.white;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;

        // Optional: Hide stop button at the beginning
        if (isStartButton && stopButton != null)
            stopButton.SetActive(false);
    }

    void OnMouseOver() => spriteRenderer.color = hoverColor;
    void OnMouseExit() => spriteRenderer.color = defaultColor;

    void OnMouseDown()
    {
        spriteRenderer.color = clickColor;
        OnButtonClick();
    }

    void OnMouseUp() => spriteRenderer.color = hoverColor;

    void OnButtonClick()
    {
        if (miniGame == null)
        {
            Debug.LogWarning("CustomButtonMG: MiniGame reference is not assigned.");
            return;
        }

        if (isStartButton)
        {
            miniGame.StartMiniGame();
            Debug.Log("🟢 StartMiniGame called.");

            if (startButton != null) startButton.SetActive(false);
            if (textBox != null) textBox.SetActive(false);
            if (stopButton != null) stopButton.SetActive(true); // 👈 Show Stop button
        }
        else
        {
            Debug.Log("🔴 StopMiniGame called.");
            miniGame.StopMiniGame();

            if (stopButton != null)
                stopButton.SetActive(false);
        }
    }
}

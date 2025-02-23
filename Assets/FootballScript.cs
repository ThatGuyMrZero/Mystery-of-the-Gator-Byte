using System.Diagnostics.Contracts;
using UnityEngine;

public class FootballScript : MonoBehaviour
{
    public GameController gameController;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool minigameActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = Color.yellow;    
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }

    private void OnMouseDown()
    {
        if (!minigameActive)
        {
            gameController.StartMinigame();
            Debug.Log("Minigame started!");
            minigameActive = true;
        }
        else
        {
            gameController.EndMinigame();
            Debug.Log("Minigame ended!");
            minigameActive = false;
        }
    }
}

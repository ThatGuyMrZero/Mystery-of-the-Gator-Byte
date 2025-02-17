using System.Diagnostics.Contracts;
using UnityEngine;

public class FootballScript : MonoBehaviour
{
    public GameController gameController;
    private SpriteRenderer spriteRenderer;
    private bool minigameActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

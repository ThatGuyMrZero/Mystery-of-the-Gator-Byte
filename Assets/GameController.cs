using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject TextBeforeGame;
    public GameObject TextAfterGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextBeforeGame.SetActive(true);
        TextAfterGame.SetActive(false);
        Debug.Log("Pregame text activated");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMinigame()
    {
        TextBeforeGame.SetActive(false);
        Debug.Log("Pregame text deactivated");
    }

    public void EndMinigame()
    {
        TextAfterGame.SetActive(true);
        Debug.Log("Endgame text activated");
    }
}

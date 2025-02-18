using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject TextBeforeGame;
    public GameObject TextAfterGame;
    public GameObject football;
    private DialogueScript dialogueScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextBeforeGame.SetActive(true);
        TextAfterGame.SetActive(false);
        football.SetActive(false);
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
        SceneManager.LoadScene("stadium_game");
    }

    public void EndMinigame()
    {
        TextAfterGame.SetActive(true);
        Debug.Log("Endgame text activated");
        SceneManager.LoadScene("stadium");
    }
}

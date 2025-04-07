using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject TextBeforeGame;
    public GameObject TextAfterGame;
    public GameObject football;
    private static bool initialized = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!initialized)
        {
            initialized = true;
            TextBeforeGame.SetActive(true);
            TextAfterGame.SetActive(false);
            football.SetActive(true);
            Debug.Log("Pregame text activated");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            EndMinigame();
        }
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
        TextBeforeGame.SetActive(false);
        football.SetActive(false);
        TextAfterGame.SetActive(true);
        Debug.Log("Endgame text activated");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "stadium" && !TextBeforeGame.activeSelf)
        {
            EndMinigame();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

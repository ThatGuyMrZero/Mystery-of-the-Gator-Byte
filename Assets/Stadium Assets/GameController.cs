using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject TextBeforeGame;
    public GameObject football;

    public TextMeshProUGUI miscText;
    public GameObject textBackground;

    private bool isPCActive = false;
    private bool isHelmetActive = false;

    private static bool initialized = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        miscText.text = "";
        textBackground.SetActive(false);

        if (!initialized)
        {
            initialized = true;
            TextBeforeGame.SetActive(true);
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
        if (InventoryManager.Instance != null && InventoryManager.Instance.items.Contains("Ripped Cloth"))
            TextBeforeGame.SetActive(false);
        Debug.Log("Returning to stadium scene...");
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

    public void PCClicked()
    {
        if (!isPCActive)
        {
            isPCActive = true;
            isHelmetActive = false;
            textBackground.SetActive(true);
            miscText.fontSize = 65;
            miscText.text = "BREAKING NEWS: Florida defeats Houston in nail-biter to win first national championship since 2007.\r\n\r\nGO GATORS!!!!";
        }
        else
        {
            isPCActive = false;
            textBackground.SetActive(false);
            miscText.text = "";
        }
    }

    public void HelmetClicked()
    {
        if (!isHelmetActive)
        {
            isHelmetActive = true;
            isPCActive = false;
            textBackground.SetActive(true);
            miscText.fontSize = 63;
            miscText.text = "Hmmm, looks like someone left their helmet here... and a football too! But I thought the team was supposed to be playing today!\r\nSomething must be wrong, maybe I should go check the football...";
        }
        else
        {
            isHelmetActive = false;
            textBackground.SetActive(false);
            miscText.text = "";
        }
    }
}

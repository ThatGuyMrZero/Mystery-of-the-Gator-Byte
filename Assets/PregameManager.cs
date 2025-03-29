using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class PregameManager : MonoBehaviour
{
    public GameObject difficultyPanel;
    public GameObject countdownPanel;
    public TextMeshProUGUI countdownText;
    public float countdownTime = 3f;
    public ScoreManager scoremanager;

    public Toggle EasyToggle;
    public Toggle NormalToggle;
    public Toggle HardToggle;

    public GameManager gamemanager;

    public GameObject gamecanvas;
    public GameObject endScreen;

    public OrderGenerator ordergenerator;

    //public TrayHandler trayhandler;
    //public OrderGenerator ordergenerator;
    //public ItemSpawner itemspawner;
    //public ItemStack itemstack;

    void Start()
    {
        endScreen.SetActive(false);
        gamecanvas.SetActive(false);
        difficultyPanel.SetActive(true);
        countdownPanel.SetActive(false);
    }

    public void OnBeginPress()
    {
        if(EasyToggle.isOn)
        {
            scoremanager.difficultyMultiplier = 0.7f;
            ordergenerator.gameDifficulty = OrderGenerator.Difficulty.Easy;
        }
        else if(NormalToggle.isOn)
        {
            scoremanager.difficultyMultiplier = 1.0f;
            ordergenerator.gameDifficulty = OrderGenerator.Difficulty.Normal;
        } 
        else if(HardToggle.isOn)
        {
            scoremanager.difficultyMultiplier = 1.5f;
            ordergenerator.gameDifficulty = OrderGenerator.Difficulty.Hard;
        }

        difficultyPanel.SetActive(false);
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        countdownPanel.SetActive(true);
        float timer = countdownTime;

        while (timer > 0)
        {
            countdownText.text = Mathf.Ceil(timer).ToString();
            yield return new WaitForSeconds(1f);
            timer--;
        }

        countdownText.text = "Start!";
        yield return new WaitForSeconds(1f);
        

        StartGame();
    }

    private void StartGame()
    {
        countdownPanel.SetActive(false);
        gamecanvas.SetActive(true);
        Debug.Log("Game Started");
        gamemanager.StartGame();
    }
}

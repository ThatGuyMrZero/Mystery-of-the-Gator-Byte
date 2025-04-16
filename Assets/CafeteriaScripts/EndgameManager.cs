using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class EndgameManager : MonoBehaviour
{

    public TextMeshProUGUI gameScore;
    public TextMeshProUGUI highScore;

    public GameObject gameCanvas;
    public GameObject endScreen;

    public ScoreManager scoremanager;

    //public void StartGame()
    //{
    //    SceneManager.LoadScene(nextScene);
    //}

    public void EndGame()
    {
        gameCanvas.SetActive(false);
        endScreen.SetActive(true);
        gameScore.text = "Score: " + scoremanager.totalScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("CafeteriaLoadingScreen", LoadSceneMode.Single);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("CafeteriaEndScreen");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FakeLoadingScreen : MonoBehaviour
{

    public Button startButton;
    public string nextScene;
    public float delay = 10f;
    public TMP_Text loadingText;
    private bool loading;
    public Slider loadingBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startButton.interactable = false;
        startButton.gameObject.SetActive(false);
        loading = true;
        StartCoroutine(EnableButtonAfterDelay());
        StartCoroutine(AnimateLoadingText());
    }

    IEnumerator EnableButtonAfterDelay()
    {
        //yield return new WaitForSeconds(delay);
        float timePassed = 0f;
        while (timePassed < delay)
        {
            timePassed += Time.deltaTime;
            loadingBar.value = (timePassed / delay) * 100;
            yield return null;
        }

        startButton.interactable = true;
        startButton.gameObject.SetActive(true);
        loading = false;
        loadingBar.gameObject.SetActive(false);
    }

    IEnumerator AnimateLoadingText()
    {
            while (loading)
            {
                loadingText.text = "Loading.";
                yield return new WaitForSeconds(0.5f);
                loadingText.text = "Loading..";
                yield return new WaitForSeconds(0.5f);
                loadingText.text = "Loading...";
                yield return new WaitForSeconds(0.5f);
            }

        loadingText.text = "Ready to start!";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextScene);
    }
}

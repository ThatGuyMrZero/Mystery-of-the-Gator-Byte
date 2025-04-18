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
    private bool initialized = false;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "CafeteriaLoadingScreen" && !initialized)
        {
            initialized = true;
            Debug.Log("Loading screen run from OnSceneLoaded function");
            Time.timeScale = 1f;

            startButton.interactable = false;
            startButton.gameObject.SetActive(false);
            loading = true;
            loadingBar.gameObject.SetActive(true);
            StartCoroutine(EnableButtonAfterDelay());
            StartCoroutine(AnimateLoadingText());
        }
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

        loading = false;
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

        loadingBar.gameObject.SetActive(false);
        loadingText.text = "Ready to start!";
        startButton.interactable = true;
        startButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(nextScene);
    }
}

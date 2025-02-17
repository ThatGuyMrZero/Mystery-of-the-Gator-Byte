using UnityEngine;
using UnityEngine.SceneManagement;
public class startMiniGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject MiniGame;
    public void StartMiniGame()
    {
        Debug.Log("Loading MiniGame Scene...");
        if (Application.CanStreamedLevelBeLoaded("MiniGame"))
        {
            Debug.Log("MiniGame Scene found! Loading now...");
            SceneManager.LoadScene("MiniGame");
        }
        else
        {
            Debug.LogError("MiniGame Scene not found! Check if it's in Build Settings.");
        }
    }

    public void BackToClassroom()
    {
        Debug.Log("Loading Main Scene...");
        SceneManager.LoadScene("ClassRoom");
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

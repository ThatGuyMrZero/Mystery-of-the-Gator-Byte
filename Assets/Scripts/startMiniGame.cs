using UnityEngine;
using UnityEngine.SceneManagement;
public class startMiniGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //public GameObject MiniGame;
    public void StartMiniGame()
    {
        if (Application.CanStreamedLevelBeLoaded("ClassroomLoadingScreen"))
        {
            SceneManager.LoadScene("ClassroomLoadingScreen");
        }
        else
        {
            Debug.LogError("ClassroomLoadingScreen Scene not found! Check if it's in Build Settings.");
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class leaveMiniGame : MonoBehaviour
{
    public void GoBackToClassroom()
    {
        Debug.Log("Button works!");
        Debug.Log("Loading classroom Scene...");
        if (Application.CanStreamedLevelBeLoaded("Classroom"))
        {
            Debug.Log("classroom Scene found! Loading now...");
            SceneManager.LoadScene("Classroom");
        }
        else
        {
            Debug.LogError("MiniGame Scene not found! Check if it's in Build Settings.");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



}

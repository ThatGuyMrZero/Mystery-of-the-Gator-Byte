using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public string SceneName;

    void LoadScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    
}

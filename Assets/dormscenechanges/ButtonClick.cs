using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string sceneToLoad;

    private void OnMouseDown()
    {
        sceneLoader.LoadScene(sceneToLoad);
    }
}

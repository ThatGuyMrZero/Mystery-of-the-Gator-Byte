using UnityEngine;
using UnityEngine.Rendering.UI;

public class DialogueScript : MonoBehaviour
{
    private Transform[] textSprites;
    private int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textSprites = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            textSprites[i] = transform.GetChild(i);
            textSprites[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button pressed!");
            CycleText();
        }
    }

    void CycleText()
    {
        if (currentIndex >= 0)
        {
            textSprites[currentIndex].gameObject.SetActive(false);
        }
        currentIndex = (currentIndex + 1) % textSprites.Length;
        textSprites[currentIndex].gameObject.SetActive(true);
    }
}

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

        // Make first text box active from the start
        textSprites[0].gameObject.SetActive(true);
        // Make text box border always active
        textSprites[textSprites.Length - 1].gameObject.SetActive(true);
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
        currentIndex = (currentIndex + 1) % (textSprites.Length - 1);
        textSprites[currentIndex].gameObject.SetActive(true);
    }
}

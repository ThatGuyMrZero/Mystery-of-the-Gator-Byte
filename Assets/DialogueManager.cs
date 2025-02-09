using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox; // Assign the text box sprite
    public GameObject[] textSprites; // Assign 8 text sprites in order
    private int currentTextIndex = 0;

    void Start()
    {
        // Hide all text sprites except the first one
        for (int i = 0; i < textSprites.Length; i++)
        {
            textSprites[i].SetActive(i == 0);
        }

        // Ensure the text box is visible
        if (textBox != null)
        {
            textBox.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click to progress dialogue
        {
            AdvanceDialogue();
        }
    }

    void AdvanceDialogue()
    {
        if (currentTextIndex < textSprites.Length - 1)
        {
            // Hide current text, show next text
            textSprites[currentTextIndex].SetActive(false);
            currentTextIndex++;
            textSprites[currentTextIndex].SetActive(true);
        }
        else
        {
            // If all text is shown, hide everything
            textSprites[currentTextIndex].SetActive(false);
            textBox.SetActive(false);
            Debug.Log("🎉 Dialogue finished! Game starts now.");
        }
    }
}

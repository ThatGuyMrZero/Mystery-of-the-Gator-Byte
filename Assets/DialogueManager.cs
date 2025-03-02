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

/*
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox; // Assign the text box sprite
    public GameObject[] textSprites; // Assign 8 text sprites in order
    public TextMeshProUGUI textComponent; // TMPro instance
    public string[] lines; // store dialogue lines in array

    private int currentTextIndex = 0;

    void Start()
    {
        // if there are textSprites, show them, otherwise show lines of text
        if (textSprites.Length > 0)
        {
             // Hide all text sprites except the first one
            for (int i = 0; i < textSprites.Length; i++)
            {
                textSprites[i].SetActive(i == 0);
            }
        }
        else if (lines.Length > 0)
        {
            // Display the first line of text if no sprites are available
            ShowLine(lines[0]);
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
        if (textSprites.Length > 0)
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
        

        else if (lines.Length > 0)
        {
            // if using lines of text, show next line
            if (currentTextIndex < lines.Length - 1)
            {
                currentTextIndex++;
                ShowLine(lines[currentTextIndex]);
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
    void ShowLine(string line)
    {
        // Display the current line of text, this could be done using a UI Text component
        Debug.Log(line); // For demonstration, we log the line
    }

}
*/
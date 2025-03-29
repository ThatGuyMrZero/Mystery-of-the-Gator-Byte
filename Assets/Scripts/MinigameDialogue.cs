using UnityEngine;
using TMPro;

public class MinigameDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    [TextArea(3, 10)]
    public string[] dialogueLines;

    private int currentLine = 0;

    void Start()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
        }
        currentLine = 0;
        ShowCurrentDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextDialogue();
        }
    }

    void ShowCurrentDialogue()
    {
        if (dialogueText != null && currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
        }
    }

    public void NextDialogue()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            ShowCurrentDialogue();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(false);
        }
    }
}

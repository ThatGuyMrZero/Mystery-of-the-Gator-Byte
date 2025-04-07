using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ClassRoomDialogue : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    [TextArea(3, 10)]
    public string[] dialogueLines;

    private int currentLine = 0;

    public static bool classroomDialogueShown = false;

    public string itemNameToAdd;


    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Classroom" && classroomDialogueShown)
        {
            if (dialoguePanel != null)
                dialoguePanel.SetActive(false);
            return;
        }

        if (dialoguePanel != null)
            dialoguePanel.SetActive(true);

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
            dialoguePanel.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Classroom")
        {
            classroomDialogueShown = true;
        }

        // ✅ Add item to inventory here
        if (InventoryManager.Instance != null && !string.IsNullOrEmpty(itemNameToAdd))
        {
            InventoryManager.Instance.AddItem(itemNameToAdd);
            Debug.Log("🎉 Added item to inventory: " + itemNameToAdd);
        }
    }

}

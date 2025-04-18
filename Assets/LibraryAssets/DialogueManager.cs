using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox; // Assign the text box sprite
    public GameObject[] textSprites; // Assign 8 text sprites in order
    public GameObject characterSprite; // Character sprite shown during first text only
    public string itemNameToAdd; // Name of the item to add to inventory
    public GameObject panelBlocker; // UI blocker to prevent other interaction
    public GameObject greenBook; // The green book to disable during dialogue

    private int currentTextIndex = 0;

    void Start()
    {
        // Enable panel blocker to prevent clicking other things
        if (panelBlocker != null)
        {
            panelBlocker.SetActive(true);
        }

        // Show first text, hide others
        for (int i = 0; i < textSprites.Length; i++)
        {
            textSprites[i].SetActive(i == 0);
        }

        // Show character sprite at start
        if (characterSprite != null)
        {
            characterSprite.SetActive(true);
        }

        // Show text box
        if (textBox != null)
        {
            textBox.SetActive(true);
        }

        // Disable interaction with green book while dialogue is active
        if (greenBook != null)
        {
            Collider2D col = greenBook.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;
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
            textSprites[currentTextIndex].SetActive(false);
            currentTextIndex++;
            textSprites[currentTextIndex].SetActive(true);

            // Hide character sprite after first text
            if (currentTextIndex > 0 && characterSprite != null)
            {
                characterSprite.SetActive(false);
            }
        }
        else
        {
            // End of dialogue
            textSprites[currentTextIndex].SetActive(false);
            textBox.SetActive(false);

            if (characterSprite != null)
            {
                characterSprite.SetActive(false);
            }

            if (panelBlocker != null)
            {
                panelBlocker.SetActive(false);
            }

            // Re-enable green book interaction
            if (greenBook != null)
            {
                Collider2D col = greenBook.GetComponent<Collider2D>();
                if (col != null)
                    col.enabled = true;
            }

            // Add item to inventory
            if (InventoryManager.Instance != null && !string.IsNullOrEmpty(itemNameToAdd))
            {
                InventoryManager.Instance.AddItem(itemNameToAdd);
                Debug.Log("✅ Added item to inventory: " + itemNameToAdd);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject[] textSprites;
    public GameObject characterSprite;
    public string itemNameToAdd;
    public GameObject panelBlocker;
    public GameObject greenBook;

    public static bool dormDialogueShown = false;

    private int currentTextIndex = 0;
    private bool dialogueWasShown = false; // ✅ Only true if full dialogue is shown this session

    void Start()
    {
        // ✅ If we've already seen Dorm dialogue, skip it
        if (SceneManager.GetActiveScene().name == "1-1" && dormDialogueShown)
        {
            if (textBox != null) textBox.SetActive(false);
            if (characterSprite != null) characterSprite.SetActive(false);
            if (panelBlocker != null) panelBlocker.SetActive(false);
            foreach (GameObject sprite in textSprites)
                if (sprite != null) sprite.SetActive(false);
            return;
        }

        dialogueWasShown = true; // ✅ Mark that dialogue is being shown

        if (panelBlocker != null)
        {
            panelBlocker.SetActive(true);
        }

        for (int i = 0; i < textSprites.Length; i++)
        {
            textSprites[i].SetActive(i == 0);
        }

        if (characterSprite != null)
        {
            characterSprite.SetActive(true);
        }

        if (textBox != null)
        {
            textBox.SetActive(true);
        }

        if (greenBook != null)
        {
            Collider2D col = greenBook.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

            if (currentTextIndex > 0 && characterSprite != null)
            {
                characterSprite.SetActive(false);
            }
        }
        else
        {
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

            if (greenBook != null)
            {
                Collider2D col = greenBook.GetComponent<Collider2D>();
                if (col != null)
                    col.enabled = true;
            }

            // ✅ Only add item if dialogue was shown and item is valid
            if (dialogueWasShown && InventoryManager.Instance != null && !string.IsNullOrEmpty(itemNameToAdd))
            {
                InventoryManager.Instance.AddItem(itemNameToAdd);
                Debug.Log("✅ Added item to inventory: " + itemNameToAdd);
            }

            // ✅ If in dorm room, mark that the dialogue has been shown
            if (SceneManager.GetActiveScene().name == "1-1")
            {
                dormDialogueShown = true;
            }
        }
    }
}

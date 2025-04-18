using UnityEngine;

public class DialogueManager1 : MonoBehaviour
{
    public GameObject textBox; // Assign the text box sprite
    public GameObject[] textSprites; // Assign 8 text sprites in order
    private int currentTextIndex = 0;
    public HoverBounce hoverBounceScript;
    public IsVisible isVisibleScript;
    public GameObject characterSprite;

    void Start()
    {
        // Hide all text sprites except the first one
        for (int i = 0; i < textSprites.Length; i++)
        {
            textSprites[i].SetActive(i == 0);
        }

        // Show character sprite only during the first text
        if (characterSprite != null)
        {
            characterSprite.SetActive(true);
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

            // Hide character sprite after first text
            if (currentTextIndex > 0 && characterSprite != null)
            {
                characterSprite.SetActive(false);
            }
        }
        else
        {
            // Hide final text and box
            textSprites[currentTextIndex].SetActive(false);
            textBox.SetActive(false);

            // ✅ Add item to inventory
       


            // Just in case, hide character sprite if still active
            if (characterSprite != null)
            {
                characterSprite.SetActive(false);
            }

        }
    }
}


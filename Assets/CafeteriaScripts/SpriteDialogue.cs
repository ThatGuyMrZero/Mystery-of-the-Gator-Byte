using UnityEngine;
using UnityEngine.UI;

public class SpriteDialogue : MonoBehaviour
{
    public Image dialogueImage; // assign in Inspector
    public Sprite[] dialogueSprites; // assign in Inspector
    private int currentIndex = 0;

    void Start()
    {
        if (dialogueSprites.Length > 0)
        {
            dialogueImage.sprite = dialogueSprites[currentIndex];
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            ShowNextDialogue();
        }
    }

    void ShowNextDialogue()
    {
        currentIndex++;
        if (currentIndex < dialogueSprites.Length)
        {
            dialogueImage.sprite = dialogueSprites[currentIndex];
        }
        else
        {
            // Dialogue ended — hide or transition
            dialogueImage.gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

public class MGDialogueManager : MonoBehaviour
{
    public GameObject dialogueBox; // Unique textbox for the mini-game dialogue
    public GameObject[] dialogueSteps; // Dialogue panels or text steps

    private int currentStepIndex = 0;

    void Start()
    {
        // Show only the first step
        for (int i = 0; i < dialogueSteps.Length; i++)
        {
            dialogueSteps[i].SetActive(i == 0);
        }

        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click to continue
        {
            AdvanceDialogue();
        }
    }

    void AdvanceDialogue()
    {
        if (currentStepIndex < dialogueSteps.Length - 1)
        {
            dialogueSteps[currentStepIndex].SetActive(false);
            currentStepIndex++;
            dialogueSteps[currentStepIndex].SetActive(true);
        }
        else
        {
            // End of dialogue
            dialogueSteps[currentStepIndex].SetActive(false);
            dialogueBox.SetActive(false);

            Debug.Log("Mini-game dialogue finished.");
        }
    }
}

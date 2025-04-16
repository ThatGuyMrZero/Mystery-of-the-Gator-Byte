using UnityEngine;

public class InstructionHandler : MonoBehaviour
{
    public GameObject instructionPanel;

    public void ShowInstructions()
    {
        instructionPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionPanel.SetActive(false);
    }
}

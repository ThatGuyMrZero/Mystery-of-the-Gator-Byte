using UnityEngine;

public class TextBoxManager : MonoBehaviour
{
    public GameObject booleanTextBox;
    public GameObject charTextBox;
    public GameObject arrayTextBox;

    void Start()
    {
        // Hide all text boxes at start
        booleanTextBox.SetActive(false);
        charTextBox.SetActive(false);
        arrayTextBox.SetActive(false);
    }

    public void ShowTextBox(string type)
    {
        // Hide all text boxes before showing the right one
        booleanTextBox.SetActive(false);
        charTextBox.SetActive(false);
        arrayTextBox.SetActive(false);

        // Show the correct text box
        if (type == "Boolean")
            booleanTextBox.SetActive(true);
        else if (type == "Char")
            charTextBox.SetActive(true);
        else if (type == "Array")
            arrayTextBox.SetActive(true);
    }

    public void HideAllTextBoxes()
    {
        // Hide all text boxes when close is clicked
        booleanTextBox.SetActive(false);
        charTextBox.SetActive(false);
        arrayTextBox.SetActive(false);
    }
}

using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; 
    public string[] lines; // store dialogue lines in array
    private int i = 0; // track current dialogue line

    void Start()
    {
        textComponent.text = string.Empty; // clear text at the start
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // detect left mouse click
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        i = 0; 
        textComponent.text = lines[i]; // show first line
    }

    void NextLine()
    {
        if (i < lines.Length - 1) 
        {
            i++; 
            textComponent.text = lines[i]; 
        }
        else
        {
            gameObject.SetActive(false); // hide textbox when finished
            Debug.Log("Dialogue done, start mini game!");
        }
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EndScreenDialogue : MonoBehaviour
{
    public GameObject textPanel;
    public List<string> textList;
    public TextMeshProUGUI endText;
    private int textIndex = 0;
    public TextMeshProUGUI buttonText;


    void Start()
    {
        textPanel.SetActive(true);
        if(textList != null && textList.Count > 0 )
        {
            endText.text = textList[0];
        }
        else
        {
            endText.text = "Let's head back to the dorm room!";
        }
    }

    public void NextText()
    {
        textIndex++;
        if (textIndex <= textList.Count - 1)
        {
            endText.text = textList[textIndex];
            if(textIndex == textList.Count - 1)
            {
                buttonText.text = "Close";
            }
        } 
        else
        {
            ClosePanel();
        }


    }

    public void ClosePanel()
    {
        textPanel.SetActive(false);
        endText.text = "";
        buttonText.text = "Next";
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ComputerDialogue : MonoBehaviour, IPointerClickHandler
{
    public GameObject ComputerPanel;


    public TextMeshProUGUI messageText;


    public string message = "Somebody left their computer here, they are going to have a hard time finishing their project.";


    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject == ComputerPanel)
        {
            ComputerPanel.SetActive(false);
        }
        else
        {

            if (ComputerPanel.activeSelf)
            {
                ComputerPanel.SetActive(false);
            }
            else
            {
                if (messageText != null)
                {
                    messageText.text = message;
                }
                ComputerPanel.SetActive(true);
            }
        }
    }
}

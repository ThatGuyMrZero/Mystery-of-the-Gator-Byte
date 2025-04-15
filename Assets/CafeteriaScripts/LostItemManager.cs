using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LostItemManager : MonoBehaviour
{
    public GameObject textPanel;
    public TextMeshProUGUI lostItemText;
    public string paperText;
    public string phoneText;
    public string bookText;

    public GameObject papers;
    public GameObject book;
    public GameObject phone;

    void Start()
    {
        textPanel.SetActive(false);
        lostItemText.text = "";
    }

    void DisableLostItems()
    {
        papers.SetActive(false);
        book.SetActive(false);
        phone.SetActive(false);
    }

    void EnableLostItems()
    {
        papers.SetActive(true);
        book.SetActive(true);
        phone.SetActive(true);
    }

    
    public void ClosePanel()
    {
        textPanel.SetActive(false);
        lostItemText.text = "";
        EnableLostItems();
    }

    public void OpenPanelPapers()
    {
        textPanel.SetActive(true);
        lostItemText.text = paperText;
        DisableLostItems();
    }

    public void OpenPanelPhone()
    {
        textPanel.SetActive(true);
        lostItemText.text = phoneText;
        DisableLostItems();
    } 
    
    public void OpenPanelBook()
    {
        textPanel.SetActive(true);
        lostItemText.text = bookText;
        DisableLostItems();
    }
}

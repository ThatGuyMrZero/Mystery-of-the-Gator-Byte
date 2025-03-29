using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class button : MonoBehaviour
{
    public Button myButton;
    private Image buttonImage;
    private bool isClicked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonImage = myButton.GetComponent<Image>();
        myButton.onClick.AddListener(ChangeColor);
    }
    void ChangeColor()
    {
        if (isClicked)
        {
            buttonImage.color = Color.white;
        }
        else
        {
            buttonImage.color = Color.red;
        }
        isClicked = !isClicked;
    }
    // Update is called once per frame
    void Update()
    {

    }
}

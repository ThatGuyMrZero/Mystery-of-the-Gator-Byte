using UnityEngine;

public class ClickableSprite : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("Sprite clicked!");
        GetComponent<SpriteRenderer>().color = Color.red; // Change color on click
    }

}

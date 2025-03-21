using UnityEngine;

public class WinSpriteHandler : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("🛑 WinSprite clicked! Hiding now...");
        gameObject.SetActive(false); // Hide the sprite when clicked
    }
}

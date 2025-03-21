using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public void ClosePopUp()
    {
        gameObject.SetActive(false); // Hides the pop-up
    }
}

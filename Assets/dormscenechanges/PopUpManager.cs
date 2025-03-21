using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUp;

    private void OnMouseDown()
    {
        popUp.SetActive(false); // Hide the pop-up
    }
}

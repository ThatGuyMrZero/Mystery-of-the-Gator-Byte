using UnityEngine;
using TMPro;

public class WinConditionManager : MonoBehaviour
{
    public DragNumbers[] draggableObjects;
    public Transform[] correctPositions;

    private bool areYaWinningSon = false;

    public TextMeshProUGUI minigameText;

    public void CheckWinCondition()
    {
        if (areYaWinningSon) return;

        bool allCorrect = true;

        for (int i = 0; i < draggableObjects.Length; i++)
        {
            float distance = Vector3.Distance(draggableObjects[i].transform.position, correctPositions[i].position);
            if (distance > draggableObjects[i].snapRange)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            Debug.Log("You are a winner!");
            areYaWinningSon = true;
            minigameText.text = "else if (score ==      ) {\r\n\tpoints +=\r\n\tif (score ==      ) {\r\n\t\tpoints +=\r\n\t} else if (score ==      ) {\r\n\t\tpoints +=\r\n\t}\r\n}";
        }
    }
}

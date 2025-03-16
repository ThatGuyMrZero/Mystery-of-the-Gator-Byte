using UnityEngine;

public class WinConditionManager : MonoBehaviour
{
    public DragNumbers[] draggableObjects;
    public Transform[] correctPositions;

    private bool areYaWinningSon = false;

    private void Update()
    {
        CheckWinCondition();
    }

    void CheckWinCondition()
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
        }
    }
}

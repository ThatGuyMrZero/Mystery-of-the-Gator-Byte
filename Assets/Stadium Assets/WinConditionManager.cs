using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinConditionManager : MonoBehaviour
{
    public DragNumbers[] draggableObjects;
    public Transform[] correctPositions;

    private bool areYaWinningSon = false;

    public TextMeshProUGUI minigameText;

    public GameObject input1;
    public GameObject input2;

    private void Start()
    {
        input1.SetActive(true);
        input2.SetActive(false);
    }

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
            SceneManager.LoadScene("stadium");
            //minigameText.text = "else if (score ==      ) {\r\n\tpoints +=\r\n\tif (score ==      ) {\r\n\t\tpoints +=\r\n\t} else if (score ==      ) {\r\n\t\tpoints +=\r\n\t}\r\n}";
            //input1.SetActive(false);
            //input2.SetActive(true);
        }
    }
}

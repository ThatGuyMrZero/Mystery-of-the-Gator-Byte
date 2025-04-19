using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using System.Collections;

public class WinConditionManager : MonoBehaviour
{
    public DragNumbers[] draggableObjectsPhase1;
    public DragNumbers[] draggableObjectsPhase2;
    public DragNumbers[] draggableObjectsPhase3;
    private DragNumbers[] draggableObjectsCurrentPhase;

    public Transform[] correctPositionsPhase1;
    public Transform[] correctPositionsPhase2;
    public Transform[] correctPositionsPhase3;
    private Transform[] correctPositionsCurrentPhase;

    private bool areYaWinningSon = false;

    public TextMeshProUGUI minigameText;

    public GameObject[] inputs;

    private DragNumbers[] allDraggables;
    private int currentPhase = 1;

    public GameObject instructions;

    private void Start()
    {
        allDraggables = FindObjectsByType<DragNumbers>(FindObjectsSortMode.None);
        
        foreach (var input in inputs)
        {
            input.SetActive(false);
        }

        draggableObjectsCurrentPhase = draggableObjectsPhase1;
        correctPositionsCurrentPhase = correctPositionsPhase1;

        foreach (DragNumbers drag in allDraggables)
        {
            drag.SetSnapTargets(correctPositionsPhase1);
        }

        instructions.SetActive(false);

        StartCoroutine(ShowInstructionsAndCountdown());
    }

    public void CheckWinCondition()
    {
        if (areYaWinningSon) return;

        bool allCorrect = true;

        for (int i = 0; i < draggableObjectsCurrentPhase.Length; i++)
        {
            float distance = Vector3.Distance(draggableObjectsCurrentPhase[i].transform.position, correctPositionsCurrentPhase[i].position);
            if (distance > draggableObjectsCurrentPhase[i].snapRange)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            if (currentPhase == 1)
            {
                Debug.Log("Phase 1 complete, moving to phase 2...");
                minigameText.text = "Correct! Now onto the else if portion...";
                inputs[0].SetActive(false);
                instructions.SetActive(false);

                // Wait for 4 seconds, then move to phase 2
                StartCoroutine(PhaseTransitionWait(4f, () =>
                {
                    minigameText.text = "else if (score ==      ) {\r\n\tpoints +=\r\n\tif (score ==      ) {\r\n\t\tpoints +=\r\n\t} else if (score ==      ) {\r\n\t\tpoints +=\r\n\t}\r\n}";
                    inputs[1].SetActive(true);
                    instructions.SetActive(true);

                    draggableObjectsCurrentPhase = draggableObjectsPhase2;
                    correctPositionsCurrentPhase = correctPositionsPhase2;

                    foreach (DragNumbers drag in allDraggables)
                    {
                        drag.SetSnapTargets(correctPositionsPhase2);
                    }

                    currentPhase = 2;
                }));
            }
            else if (currentPhase == 2)
            {
                Debug.Log("Phase 2 complete, moving to phase 3...");
                minigameText.text = "Correct! You're almost there, now just the else block is left!";
                inputs[1].SetActive(false);
                instructions.SetActive(false);

                // Wait for 4 seconds, then move to phase 3
                StartCoroutine(PhaseTransitionWait(4f, () =>
                {
                    minigameText.text = "else {\r\n\tpoints += \r\n}";
                    inputs[2].SetActive(true);
                    instructions.SetActive(true);

                    draggableObjectsCurrentPhase = draggableObjectsPhase3;
                    correctPositionsCurrentPhase = correctPositionsPhase3;

                    foreach (DragNumbers drag in allDraggables)
                    {
                        drag.SetSnapTargets(correctPositionsPhase3);
                    }

                    currentPhase = 3;
                }));
            }
            else if (currentPhase == 3)
            {
                Debug.Log("Minigame complete!");
                minigameText.text = "Congratulations, you successfully filled in the if-else statement and completed the minigame!";
                inputs[2].SetActive(false);
                instructions.SetActive(false);

                // Wait for 4 seconds, then return to the main stadium scene
                StartCoroutine(PhaseTransitionWait(4f, () =>
                {
                    areYaWinningSon = true;
                    SceneManager.LoadScene("stadium_end");           
                }));
            }

            StartCoroutine(SnapAllObjectsBack());
            allCorrect = false;
        }
    }

    public void DisableCurrentPhase()
    {
        inputs[currentPhase - 1].SetActive(false);
        StartCoroutine(SnapAllObjectsBack());
        minigameText.fontSize = 9;
        minigameText.text = "Instructions\r\n\r\nYou will be presented with an incomplete portion of a standard if-else statement. Your goal is to use the numbers below you and the scoring methods to the right to correctly complete the statement defining scoring methods in football and the points each method earns.\r\n\r\nDrag each number or scoring method into one of the white rectangles to fill in your answer. Upon successful completion of each phase, the next one will begin immediately after. There are 3 phases in total.\r\n\r\nAs a review, here are the basic rules of scoring in football:\r\n* A SAFETY is worth 2 points.\r\n* A FIELD GOAL is worth 3 points.\r\n* A TOUCHDOWN is worth 6 points.\r\n\t* After a touchdown, either a KICK can be performed afterwards for 1 additional point, or a TWO-POINT CONVERSION, which should be self-explanatory.\r\n\r\nYou can review the rules at any time by clicking the ? in the upper-left hand corner.\r\n\r\nClick the ? again to close these instructions and return to the game.\r\nIf for any reason your objects are pushed off-screen, the ? will reset all objects back to their original position.";
    }

    public void ReenableCurrentPhase()
    {
        inputs[currentPhase - 1].SetActive(true);
        minigameText.fontSize = 24;

        switch (currentPhase)
        {
            case 1:
                minigameText.text = "points = 0\r\nif (score ==      ) {\r\n\tpoints += \r\n}\r\nelse if (score ==      ) {\r\n\tpoints += \r\n}";
                break;
            case 2:
                minigameText.text = "else if (score ==      ) {\r\n\tpoints +=\r\n\tif (score ==      ) {\r\n\t\tpoints +=\r\n\t} else if (score ==      ) {\r\n\t\tpoints +=\r\n\t}\r\n}";
                break;
            case 3:
                minigameText.text = "else {\r\n\tpoints += \r\n}";
                break;
        }
    }

    private IEnumerator PhaseTransitionWait(float waitTime, System.Action onComplete)
    {
        yield return new WaitForSeconds(waitTime);
        onComplete?.Invoke();
    }

    private System.Collections.IEnumerator SnapAllObjectsBack()
    {
        yield return null;

        foreach (DragNumbers dragNumbers in allDraggables)
        {
            dragNumbers.SnapBackToPosition();
        }
    }

    private IEnumerator ShowInstructionsAndCountdown()
    {
        Time.timeScale = 1f;
        minigameText.fontSize = 9;

        for (int i = 10; i > 0; i--)
        {
            minigameText.text = $"Instructions\r\n\r\nYou will be presented with an incomplete portion of a standard if-else statement. Your goal is to use the numbers below you and the scoring methods to the right to correctly complete the statement defining scoring methods in football and the points each method earns.\r\n\r\nDrag each number or scoring method into one of the white rectangles to fill in your answer. Upon successful completion of each phase, the next one will begin immediately after. There are 3 phases in total.\r\n\r\nAs a review, here are the basic rules of scoring in football:\r\n* A SAFETY is worth 2 points.\r\n* A FIELD GOAL is worth 3 points.\r\n* A TOUCHDOWN is worth 6 points.\r\n\t* After a touchdown, either a KICK can be performed afterwards for 1 additional point, or a TWO-POINT CONVERSION, which should be self-explanatory.\r\n\r\nYou can review the rules at any time by clicking the ? in the upper-left hand corner.\r\n\r\nThe minigame will begin in {i} second{(i == 1 ? "" : "s")}. Good luck!";
            yield return new WaitForSeconds(1f);
        }

        minigameText.fontSize = 24;
        minigameText.text = "points = 0\r\nif (score ==      ) {\r\n\tpoints += \r\n}\r\nelse if (score ==      ) {\r\n\tpoints += \r\n}";

        inputs[0].SetActive(true);
        instructions.SetActive(true);
    }
}

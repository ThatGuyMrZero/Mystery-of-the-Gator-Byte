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

    private void Start()
    {
        allDraggables = FindObjectsByType<DragNumbers>(FindObjectsSortMode.None);
        
        foreach (var input in inputs)
        {
            input.SetActive(false);
        }

        inputs[currentPhase - 1].SetActive(true);

        draggableObjectsCurrentPhase = draggableObjectsPhase1;
        correctPositionsCurrentPhase = correctPositionsPhase1;

        foreach (DragNumbers drag in allDraggables)
        {
            drag.SetSnapTargets(correctPositionsPhase1);
        }
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

                // Wait for 4 seconds, then move to phase 2
                StartCoroutine(PhaseTransitionWait(4f, () =>
                {
                    minigameText.text = "else if (score ==      ) {\r\n\tpoints +=\r\n\tif (score ==      ) {\r\n\t\tpoints +=\r\n\t} else if (score ==      ) {\r\n\t\tpoints +=\r\n\t}\r\n}";
                    inputs[1].SetActive(true);
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

                // Wait for 4 seconds, then move to phase 3
                StartCoroutine(PhaseTransitionWait(4f, () =>
                {
                    minigameText.text = "else {\r\n\tpoints += \r\n}";
                    inputs[2].SetActive(true);
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

                // Wait for 4 seconds, then return to the main stadium scene
                StartCoroutine(PhaseTransitionWait(4f, () =>
                {
                    areYaWinningSon = true;
                    SceneManager.LoadScene("stadium");           
                }));
            }

            StartCoroutine(SnapAllObjectsBack());
            allCorrect = false;
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
}

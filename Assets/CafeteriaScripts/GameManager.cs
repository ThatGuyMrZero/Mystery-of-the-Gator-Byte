using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;

    public void StartGame()
    {
        Debug.Log("Game started event pushed");
        OnGameStart?.Invoke();
    }
}

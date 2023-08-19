using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool gameInProgress;

    private void Start()
    {
        gameInProgress = true;
    }

    public void EndGame()
    {
        gameInProgress = false;
    }
}

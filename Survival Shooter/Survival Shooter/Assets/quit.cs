using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();

    }
}
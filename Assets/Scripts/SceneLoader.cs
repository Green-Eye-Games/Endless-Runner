using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadMenuScene(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameEvent gameOver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameOver.Raise();
            Debug.Log("lose game");
            SceneLoader.LoadMenuScene(0);
        }
    }
}

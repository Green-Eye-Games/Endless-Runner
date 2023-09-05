using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureManager : MonoBehaviour
{
    LevelGenerator lg;

    private void Start()
    {
        lg = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
    }

    private void OnBecameInvisible()
    {
        if (GameState.gameInProgress)
        {
            if (gameObject.transform.position.x > 0)
            {
                lg.SpawnStructuresRight();
                this.gameObject.SetActive(false);
            }

            else
            {
                lg.SpawnStructuresLeft();
                this.gameObject.SetActive(false);
            }
        }
    }
}

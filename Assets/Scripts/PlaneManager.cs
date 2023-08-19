using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
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
            lg.SpawnPlanes();
            this.gameObject.SetActive(false);
        }
    }
}

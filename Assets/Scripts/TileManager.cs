using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    LevelGenerator lg;
    private void Start()
    {
        lg = GameObject.Find("LevelGenerator").GetComponent<LevelGenerator>();
    }
    private void OnBecameInvisible()
    {
        if (ObjectPooler.SharedInstance != null)
        {
            lg.SpawnTiles();
            this.gameObject.SetActive(false);
        }
        //lg.SpawnTiles();
        //this.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledTiles;
    public List<GameObject> pooledPlanes;
    public List<GameObject> pooledCones;

    public GameObject tiles;
    public GameObject planes;
    public GameObject cones;

    public int tilesToPool;
    public int planesToPool;
    public int conesToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledTiles = new List<GameObject>();
        GameObject tmpTile;
        for (int i = 0; i < tilesToPool; i++)
        {
            tmpTile = Instantiate(tiles);
            tmpTile.SetActive(false);
            pooledTiles.Add(tmpTile);
        }

        pooledPlanes = new List<GameObject>();
        GameObject tmpPlane;
        for (int i = 0; i < planesToPool; i++)
        {
            tmpPlane = Instantiate(planes);
            tmpPlane.SetActive(false);
            pooledPlanes.Add(tmpPlane);
        }

        pooledCones = new List<GameObject>();
        GameObject tmpcone;
        for (int i = 0; i < conesToPool; i++)
        {
            tmpcone = Instantiate(cones);
            tmpcone.SetActive(false);
            pooledCones.Add(tmpcone);
        }
    }
    public GameObject GetPooledTileObject()
    {
        for (int i = 0; i < tilesToPool; i++)
        {
            if (!pooledTiles[i].activeInHierarchy)
            {
                return pooledTiles[i];
            }
        }
        return null;
    }

    public GameObject GetPooledPlaneObject()
    {
        for (int i = 0; i < planesToPool; i++)
        {
            if (!pooledPlanes[i].activeInHierarchy)
            {
                return pooledPlanes[i];
            }
        }
        return null;
    }

    public GameObject GetPooledConeObject()
    {
        for (int i = 0; i < conesToPool; i++)
        {
            if (!pooledCones[i].activeInHierarchy)
            {
                return pooledCones[i];
            }
        }
        return null;
    }
}

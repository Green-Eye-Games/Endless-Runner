using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledTiles;
    public List<GameObject> pooledPlanes;
    public List<GameObject> pooledCones;
    public List<GameObject> pooledHouse_5;

    public GameObject tiles;
    public GameObject planes;
    public GameObject cones;
    public GameObject house_5;

    public int tilesToPool;
    public int planesToPool;
    public int conesToPool;
    public int house_5ToPool;

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

        pooledHouse_5 = new List<GameObject>();
        GameObject tmpHouse_5;
        for (int i = 0; i < house_5ToPool; i++)
        {
            tmpHouse_5 = Instantiate(house_5);
            tmpHouse_5.SetActive(false);
            pooledHouse_5.Add(tmpHouse_5);
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

    public GameObject GetPooledHouse_5Object()
    {
        for (int i = 0; i < house_5ToPool; i++)
        {
            if (!pooledHouse_5[i].activeInHierarchy)
            {
                return pooledHouse_5[i];
            }
        }
        return null;
    }
}

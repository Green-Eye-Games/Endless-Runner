using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject roadTile;
    public GameObject plane;
    [SerializeField]
    GameObject trashcan;
    [SerializeField]
    GameObject trafficCone;
    [SerializeField]
    GameObject barrel;
    [SerializeField]
    GameObject house_5;

    Vector3 currentTileSpawnPosition;
    Vector3 currentPlaneSpawnPosition;
    Vector3 currentConeSpawnPosition;
    Vector3 currentHouse_5SpawnPosition;
    Vector3 currentHouse_5RightSpawnPosition;

    void Start()
    {
        currentTileSpawnPosition = new Vector3(0, 0, -9);
        currentPlaneSpawnPosition = new Vector3(0, 0, 0);
        currentConeSpawnPosition = new Vector3(0, 0.4f, 10);
        currentHouse_5SpawnPosition = new Vector3(-12, 0, 0);
        currentHouse_5RightSpawnPosition = new Vector3(12, 0, 0);
        GenerateLevelStart();
    }

    void GenerateLevelStart()
    {
        for (int i = 0; i < 70; i++)
        {
            GameObject roadTile = ObjectPooler.SharedInstance.GetPooledTileObject();
            if (roadTile != null)
            {
                roadTile.transform.position = currentTileSpawnPosition;
                roadTile.SetActive(true);
                currentTileSpawnPosition.z += 9;
            }
        }

        for (int i = 0; i < 7; i++)
        {
            GameObject planeTile = ObjectPooler.SharedInstance.GetPooledPlaneObject();
            if (planeTile != null)
            {
                planeTile.transform.position = currentPlaneSpawnPosition;
                planeTile.SetActive(true);
                currentPlaneSpawnPosition.z += 200;
            }
        }

        for (int i = 0; i < 1; i++)
        {
            GameObject cone = ObjectPooler.SharedInstance.GetPooledConeObject();
            if (cone != null)
            {
                cone.transform.position = currentConeSpawnPosition;
                cone.SetActive(true);
                currentConeSpawnPosition.z += 3;
                Debug.Log(currentConeSpawnPosition);
            }
        }

        for (int i = 0; i < 25; i++)
        {
            GameObject house_5 = ObjectPooler.SharedInstance.GetPooledHouse_5Object();
            if (house_5 != null)
            {
                house_5.transform.position = currentHouse_5SpawnPosition;
                house_5.SetActive(true);
                currentHouse_5SpawnPosition.z += 22;
            }
        }

        for (int i = 0; i < 25; i++)
        {
            GameObject house_5 = ObjectPooler.SharedInstance.GetPooledHouse_5Object();
            if (house_5 != null)
            {
                house_5.transform.position = currentHouse_5RightSpawnPosition;
                house_5.transform.eulerAngles = new Vector3(0, -90, 0); 
                house_5.SetActive(true);
                currentHouse_5RightSpawnPosition.z += 22;
            }
        }
    }

    public void SpawnPlanes()
    {
        GameObject planeTile = ObjectPooler.SharedInstance.GetPooledPlaneObject();
        if (planeTile != null)
        {
            planeTile.transform.position = currentPlaneSpawnPosition;
            planeTile.SetActive(true);
            currentPlaneSpawnPosition.z += 200;
        }
    }

    public void SpawnTiles()
    {
        GameObject roadTile = ObjectPooler.SharedInstance.GetPooledTileObject();
        if (roadTile != null)
        {
            roadTile.transform.position = currentTileSpawnPosition;
            roadTile.SetActive(true);
            currentTileSpawnPosition.z += 9;
        }
    }

    public void SpawnCones()
    {
        GameObject cone = ObjectPooler.SharedInstance.GetPooledConeObject();
        if (cone != null)
        {
            cone.transform.position = currentConeSpawnPosition;
            cone.SetActive(true);
            currentConeSpawnPosition.z += 9;
        }
    }
}

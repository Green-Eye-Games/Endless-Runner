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

    Vector3 currentTileSpawnPosition;
    Vector3 currentPlaneSpawnPosition;
    Vector3 currentConeSpawnPosition;

    void Start()
    {
        currentTileSpawnPosition = new Vector3(0, 0, -9);
        currentPlaneSpawnPosition = new Vector3(0, 0, 0);
        currentConeSpawnPosition = new Vector3(0, 0.4f, 10);
        GenerateLevelStart();
    }

    void Update()
    {
    }

    void GenerateLevelStart()
    {
        for (int i = 0; i < 70; i++)
        {
            //GameObject.Instantiate(roadTile, currentTileSpawnPosition, Quaternion.Euler(0, 0, 0));
            //currentTileSpawnPosition.z += 9;

            GameObject roadTile = ObjectPooler.SharedInstance.GetPooledTileObject();
            if (roadTile != null)
            {
                //bullet.transform.position = turret.transform.position;
                roadTile.transform.position = currentTileSpawnPosition;
                //bullet.transform.rotation = turret.transform.rotation;
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

        for (int i = 0; i < 5; i++)
        {
            GameObject cone = ObjectPooler.SharedInstance.GetPooledConeObject();
            if (cone != null)
            {
                cone.transform.position = currentConeSpawnPosition;
                cone.SetActive(true);
                currentConeSpawnPosition.z += 3;
            }
        }
    }

    public void SpawnPlanes()
    {
        GameObject planeTile = ObjectPooler.SharedInstance.GetPooledPlaneObject();
        if (roadTile != null)
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

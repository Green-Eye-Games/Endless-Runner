using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject roadTile;
    public GameObject plane;
    [SerializeField]
    GameObject cubeStack;

    Vector3 currentSpawnPosition;

    int planeSpawnPosition = 0;

    void Start()
    {
        currentSpawnPosition = new Vector3(0, 0, 0);
        GenerateLevelStart();
    }

    void Update()
    {
    }

    void GenerateLevelStart()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject.Instantiate(roadTile, currentSpawnPosition, Quaternion.Euler(0, 0, 0));
            currentSpawnPosition.z += 9;
        }

        for (int i = 0; i < 3; i++)
        {
            GameObject.Instantiate(plane, new Vector3(0, 0, planeSpawnPosition), Quaternion.Euler(0, 0, 0));
           planeSpawnPosition += 200;
        }
    }

    public void SpwanPlane()
    {
        Instantiate(plane, new Vector3(0, 0, planeSpawnPosition), Quaternion.Euler(0, 0, 0));
        planeSpawnPosition += 200;
    }

    void spawnTiles()
    {
        GameObject.Instantiate(roadTile, currentSpawnPosition, Quaternion.Euler(0, 0, 0));
        currentSpawnPosition.z += 9;
    }
}

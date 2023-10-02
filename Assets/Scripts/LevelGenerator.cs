using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject roadTile;
    public GameObject plane;
    public GameObject[] obstaclePrefabs;
    public GameObject collectiblePrefab;

    public StructurePattern[] structurePatterns;

    Vector3 currentTileSpawnPosition;
    Vector3 currentPlaneSpawnPosition;
    Vector3 currentConeSpawnPosition;

    int structureIndex;

    float currentStructureRightSpawnPosition = 0;
    float currentStructureLeftSpawnPosition = 0;
    float groupDistance = 50f;
    float lastGroupPosition;

    public Player player;

    enum Lanestate
    {
        left,
        middle,
        right
    }

    Lanestate lanestate;

    void Start()
    {
        currentTileSpawnPosition = new Vector3(0, 0, -9);
        currentPlaneSpawnPosition = new Vector3(0, 0, 0);
        currentConeSpawnPosition = new Vector3(0, 0.4f, 10);
        lastGroupPosition = 0f;
        GenerateLevelStart();
        SpawnObstacleGroup();
    }

    void Update()
    {
        if (player.transform.position.z >= lastGroupPosition + groupDistance)
        {
            SpawnObstacleGroup();
        }
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

        //for (int i = 0; i < 25; i++)
        //{
        //    GameObject cone = ObjectPooler.SharedInstance.GetPooledConeObject();
        //    if (cone != null)
        //    {
        //        cone.transform.position = currentConeSpawnPosition;
        //        cone.SetActive(true);
        //        currentConeSpawnPosition.z += 3;
        //        Debug.Log(currentConeSpawnPosition);
        //    }
        //}

        for (int i = 0; i < 25; i++)
        {
            GameObject structure = ObjectPooler.SharedInstance.GetPooledStructureObject(out structureIndex);
            if (structure != null)
            {
                Vector3 structureOffset = Vector3.zero;
                switch (structureIndex)
                {
                    case >= 0 and <= 14:
                        Debug.Log("basketball");
                        structureOffset = new Vector3(structurePatterns[0].xValue, structurePatterns[0].zIncrement, structurePatterns[0].rotation);
                        break;
                    case >= 15 and <= 29:
                        Debug.Log("burgers");
                        structureOffset = new Vector3(structurePatterns[1].xValue, structurePatterns[1].zIncrement, structurePatterns[1].rotation);
                        break;
                    case >= 30 and <= 44:
                        Debug.Log("cinema");
                        structureOffset = new Vector3(structurePatterns[2].xValue, structurePatterns[2].zIncrement, structurePatterns[2].rotation);
                        break;
                    case >= 45 and <= 59:
                        Debug.Log("coffee");
                        structureOffset = new Vector3(structurePatterns[3].xValue, structurePatterns[3].zIncrement, structurePatterns[3].rotation);
                        break;
                    case >= 60 and <= 74:
                        Debug.Log("construction");
                        structureOffset = new Vector3(structurePatterns[4].xValue, structurePatterns[4].zIncrement, structurePatterns[4].rotation);
                        break;
                    case >= 75 and <= 89:
                        Debug.Log("house1");
                        structureOffset = new Vector3(structurePatterns[5].xValue, structurePatterns[5].zIncrement, structurePatterns[5].rotation);
                        break;
                    case >= 90 and <= 104:
                        Debug.Log("house5");
                        structureOffset = new Vector3(structurePatterns[6].xValue, structurePatterns[6].zIncrement, structurePatterns[6].rotation);
                        break;
                    case >= 105 and <= 119:
                        Debug.Log("house7");
                        structureOffset = new Vector3(structurePatterns[7].xValue, structurePatterns[7].zIncrement, structurePatterns[7].rotation);
                        break;
                    case >= 120 and <= 134:
                        Debug.Log("pizza");
                        structureOffset = new Vector3(structurePatterns[8].xValue, structurePatterns[8].zIncrement, structurePatterns[8].rotation);
                        break;
                    case >= 135 and <= 149:
                        Debug.Log("smallhouse");
                        structureOffset = new Vector3(structurePatterns[9].xValue, structurePatterns[9].zIncrement, structurePatterns[9].rotation);
                        break;
                    case >= 150 and <= 164:
                        Debug.Log("suburb1");
                        structureOffset = new Vector3(structurePatterns[10].xValue, structurePatterns[10].zIncrement, structurePatterns[10].rotation);
                        break;
                    case >= 165 and <= 179:
                        Debug.Log("suburb2");
                        structureOffset = new Vector3(structurePatterns[11].xValue, structurePatterns[11].zIncrement, structurePatterns[11].rotation);
                        break;
                    case >= 180 and <= 194:
                        Debug.Log("suburb4");
                        structureOffset = new Vector3(structurePatterns[12].xValue, structurePatterns[12].zIncrement, structurePatterns[12].rotation);
                        break;
                    case >= 195 and <= 209:
                        Debug.Log("supermarket");
                        structureOffset = new Vector3(structurePatterns[13].xValue, structurePatterns[13].zIncrement, structurePatterns[13].rotation);
                        break;
                    case >= 210 and <= 224:
                        Debug.Log("sushi");
                        structureOffset = new Vector3(structurePatterns[14].xValue, structurePatterns[14].zIncrement, structurePatterns[14].rotation);
                        break;
                }

                structure.transform.position = new Vector3(structureOffset.x, 0, currentStructureRightSpawnPosition);
                structure.transform.rotation = Quaternion.Euler(0, structureOffset.z, 0);
                structure.SetActive(true);
                currentStructureRightSpawnPosition += structureOffset.y;
            }
        }

        for (int i = 0; i < 25; i++)
        {
            GameObject structure = ObjectPooler.SharedInstance.GetPooledStructureObject(out structureIndex);
            if (structure != null)
            {
                Vector3 structureOffset = Vector3.zero;
                switch (structureIndex)
                {
                    case >= 0 and <= 14:
                        Debug.Log("basketball");
                        structureOffset = new Vector3(structurePatterns[0].xValue, structurePatterns[0].zIncrement, structurePatterns[0].rotation);
                        break;
                    case >= 15 and <= 29:
                        Debug.Log("burgers");
                        structureOffset = new Vector3(structurePatterns[1].xValue, structurePatterns[1].zIncrement, structurePatterns[1].rotation);
                        break;
                    case >= 30 and <= 44:
                        Debug.Log("cinema");
                        structureOffset = new Vector3(structurePatterns[2].xValue, structurePatterns[2].zIncrement, structurePatterns[2].rotation);
                        break;
                    case >= 45 and <= 59:
                        Debug.Log("coffee");
                        structureOffset = new Vector3(structurePatterns[3].xValue, structurePatterns[3].zIncrement, structurePatterns[3].rotation);
                        break;
                    case >= 60 and <= 74:
                        Debug.Log("construction");
                        structureOffset = new Vector3(structurePatterns[4].xValue, structurePatterns[4].zIncrement, structurePatterns[4].rotation);
                        break;
                    case >= 75 and <= 89:
                        Debug.Log("house1");
                        structureOffset = new Vector3(structurePatterns[5].xValue, structurePatterns[5].zIncrement, structurePatterns[5].rotation);
                        break;
                    case >= 90 and <= 104:
                        Debug.Log("house5");
                        structureOffset = new Vector3(structurePatterns[6].xValue, structurePatterns[6].zIncrement, structurePatterns[6].rotation);
                        break;
                    case >= 105 and <= 119:
                        Debug.Log("house7");
                        structureOffset = new Vector3(structurePatterns[7].xValue, structurePatterns[7].zIncrement, structurePatterns[7].rotation);
                        break;
                    case >= 120 and <= 134:
                        Debug.Log("pizza");
                        structureOffset = new Vector3(structurePatterns[8].xValue, structurePatterns[8].zIncrement, structurePatterns[8].rotation);
                        break;
                    case >= 135 and <= 149:
                        Debug.Log("smallhouse");
                        structureOffset = new Vector3(structurePatterns[9].xValue, structurePatterns[9].zIncrement, structurePatterns[9].rotation);
                        break;
                    case >= 150 and <= 164:
                        Debug.Log("suburb1");
                        structureOffset = new Vector3(structurePatterns[10].xValue, structurePatterns[10].zIncrement, structurePatterns[10].rotation);
                        break;
                    case >= 165 and <= 179:
                        Debug.Log("suburb2");
                        structureOffset = new Vector3(structurePatterns[11].xValue, structurePatterns[11].zIncrement, structurePatterns[11].rotation);
                        break;
                    case >= 180 and <= 194:
                        Debug.Log("suburb4");
                        structureOffset = new Vector3(structurePatterns[12].xValue, structurePatterns[12].zIncrement, structurePatterns[12].rotation);
                        break;
                    case >= 195 and <= 209:
                        Debug.Log("supermarket");
                        structureOffset = new Vector3(structurePatterns[13].xValue, structurePatterns[13].zIncrement, structurePatterns[13].rotation);
                        break;
                    case >= 210 and <= 224:
                        Debug.Log("sushi");
                        structureOffset = new Vector3(structurePatterns[14].xValue, structurePatterns[14].zIncrement, structurePatterns[14].rotation);
                        break;
                }

                structure.transform.position = new Vector3(-structureOffset.x, 0, currentStructureLeftSpawnPosition);
                structure.transform.rotation = Quaternion.Euler(0, (structureOffset.z - 180), 0);
                structure.SetActive(true);
                currentStructureLeftSpawnPosition += structureOffset.y;
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

    public void SpawnStructuresRight()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject structure = ObjectPooler.SharedInstance.GetPooledStructureObject(out structureIndex);
            if (structure != null)
            {
                Vector3 structureOffset = Vector3.zero;
                switch (structureIndex)
                {
                    case >= 0 and <= 14:
                        Debug.Log("basketball");
                        structureOffset = new Vector3(structurePatterns[0].xValue, structurePatterns[0].zIncrement, structurePatterns[0].rotation);
                        break;
                    case >= 15 and <= 29:
                        Debug.Log("burgers");
                        structureOffset = new Vector3(structurePatterns[1].xValue, structurePatterns[1].zIncrement, structurePatterns[1].rotation);
                        break;
                    case >= 30 and <= 44:
                        Debug.Log("cinema");
                        structureOffset = new Vector3(structurePatterns[2].xValue, structurePatterns[2].zIncrement, structurePatterns[2].rotation);
                        break;
                    case >= 45 and <= 59:
                        Debug.Log("coffee");
                        structureOffset = new Vector3(structurePatterns[3].xValue, structurePatterns[3].zIncrement, structurePatterns[3].rotation);
                        break;
                    case >= 60 and <= 74:
                        Debug.Log("construction");
                        structureOffset = new Vector3(structurePatterns[4].xValue, structurePatterns[4].zIncrement, structurePatterns[4].rotation);
                        break;
                    case >= 75 and <= 89:
                        Debug.Log("house1");
                        structureOffset = new Vector3(structurePatterns[5].xValue, structurePatterns[5].zIncrement, structurePatterns[5].rotation);
                        break;
                    case >= 90 and <= 104:
                        Debug.Log("house5");
                        structureOffset = new Vector3(structurePatterns[6].xValue, structurePatterns[6].zIncrement, structurePatterns[6].rotation);
                        break;
                    case >= 105 and <= 119:
                        Debug.Log("house7");
                        structureOffset = new Vector3(structurePatterns[7].xValue, structurePatterns[7].zIncrement, structurePatterns[7].rotation);
                        break;
                    case >= 120 and <= 134:
                        Debug.Log("pizza");
                        structureOffset = new Vector3(structurePatterns[8].xValue, structurePatterns[8].zIncrement, structurePatterns[8].rotation);
                        break;
                    case >= 135 and <= 149:
                        Debug.Log("smallhouse");
                        structureOffset = new Vector3(structurePatterns[9].xValue, structurePatterns[9].zIncrement, structurePatterns[9].rotation);
                        break;
                    case >= 150 and <= 164:
                        Debug.Log("suburb1");
                        structureOffset = new Vector3(structurePatterns[10].xValue, structurePatterns[10].zIncrement, structurePatterns[10].rotation);
                        break;
                    case >= 165 and <= 179:
                        Debug.Log("suburb2");
                        structureOffset = new Vector3(structurePatterns[11].xValue, structurePatterns[11].zIncrement, structurePatterns[11].rotation);
                        break;
                    case >= 180 and <= 194:
                        Debug.Log("suburb4");
                        structureOffset = new Vector3(structurePatterns[12].xValue, structurePatterns[12].zIncrement, structurePatterns[12].rotation);
                        break;
                    case >= 195 and <= 209:
                        Debug.Log("supermarket");
                        structureOffset = new Vector3(structurePatterns[13].xValue, structurePatterns[13].zIncrement, structurePatterns[13].rotation);
                        break;
                    case >= 210 and <= 224:
                        Debug.Log("sushi");
                        structureOffset = new Vector3(structurePatterns[14].xValue, structurePatterns[14].zIncrement, structurePatterns[14].rotation);
                        break;
                }

                structure.transform.position = new Vector3(structureOffset.x, 0, currentStructureRightSpawnPosition);
                structure.transform.rotation = Quaternion.Euler(0, structureOffset.z, 0);
                structure.SetActive(true);
                currentStructureRightSpawnPosition += structureOffset.y;
            }
        }
    }

    public void SpawnStructuresLeft()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject structure = ObjectPooler.SharedInstance.GetPooledStructureObject(out structureIndex);
            if (structure != null)
            {
                Vector3 structureOffset = Vector3.zero;
                switch (structureIndex)
                {
                    case >= 0 and <= 14:
                        Debug.Log("basketball");
                        structureOffset = new Vector3(structurePatterns[0].xValue, structurePatterns[0].zIncrement, structurePatterns[0].rotation);
                        break;
                    case >= 15 and <= 29:
                        Debug.Log("burgers");
                        structureOffset = new Vector3(structurePatterns[1].xValue, structurePatterns[1].zIncrement, structurePatterns[1].rotation);
                        break;
                    case >= 30 and <= 44:
                        Debug.Log("cinema");
                        structureOffset = new Vector3(structurePatterns[2].xValue, structurePatterns[2].zIncrement, structurePatterns[2].rotation);
                        break;
                    case >= 45 and <= 59:
                        Debug.Log("coffee");
                        structureOffset = new Vector3(structurePatterns[3].xValue, structurePatterns[3].zIncrement, structurePatterns[3].rotation);
                        break;
                    case >= 60 and <= 74:
                        Debug.Log("construction");
                        structureOffset = new Vector3(structurePatterns[4].xValue, structurePatterns[4].zIncrement, structurePatterns[4].rotation);
                        break;
                    case >= 75 and <= 89:
                        Debug.Log("house1");
                        structureOffset = new Vector3(structurePatterns[5].xValue, structurePatterns[5].zIncrement, structurePatterns[5].rotation);
                        break;
                    case >= 90 and <= 104:
                        Debug.Log("house5");
                        structureOffset = new Vector3(structurePatterns[6].xValue, structurePatterns[6].zIncrement, structurePatterns[6].rotation);
                        break;
                    case >= 105 and <= 119:
                        Debug.Log("house7");
                        structureOffset = new Vector3(structurePatterns[7].xValue, structurePatterns[7].zIncrement, structurePatterns[7].rotation);
                        break;
                    case >= 120 and <= 134:
                        Debug.Log("pizza");
                        structureOffset = new Vector3(structurePatterns[8].xValue, structurePatterns[8].zIncrement, structurePatterns[8].rotation);
                        break;
                    case >= 135 and <= 149:
                        Debug.Log("smallhouse");
                        structureOffset = new Vector3(structurePatterns[9].xValue, structurePatterns[9].zIncrement, structurePatterns[9].rotation);
                        break;
                    case >= 150 and <= 164:
                        Debug.Log("suburb1");
                        structureOffset = new Vector3(structurePatterns[10].xValue, structurePatterns[10].zIncrement, structurePatterns[10].rotation);
                        break;
                    case >= 165 and <= 179:
                        Debug.Log("suburb2");
                        structureOffset = new Vector3(structurePatterns[11].xValue, structurePatterns[11].zIncrement, structurePatterns[11].rotation);
                        break;
                    case >= 180 and <= 194:
                        Debug.Log("suburb4");
                        structureOffset = new Vector3(structurePatterns[12].xValue, structurePatterns[12].zIncrement, structurePatterns[12].rotation);
                        break;
                    case >= 195 and <= 209:
                        Debug.Log("supermarket");
                        structureOffset = new Vector3(structurePatterns[13].xValue, structurePatterns[13].zIncrement, structurePatterns[13].rotation);
                        break;
                    case >= 210 and <= 224:
                        Debug.Log("sushi");
                        structureOffset = new Vector3(structurePatterns[14].xValue, structurePatterns[14].zIncrement, structurePatterns[14].rotation);
                        break;
                }

                structure.transform.position = new Vector3(-structureOffset.x, 0, currentStructureLeftSpawnPosition);
                structure.transform.rotation = Quaternion.Euler(0, (structureOffset.z - 180), 0);
                structure.SetActive(true);
                currentStructureLeftSpawnPosition += structureOffset.y;
            }
        }
    }

    private void SpawnObstacleGroup()
    {
        int collectiblesPerGroup = Random.Range(200, 200); 

        //for (int i = 0; i < obstaclesPerGroup; i++)
        //{
        //    // Spawn obstacles
        //    Vector3 obstacleSpawnPosition = new Vector3(lastGroupPosition + i * 2f, 0f, 0f);
        //    Quaternion obstacleSpawnRotation = Quaternion.identity;
        //    GameObject obstacle = Instantiate(obstaclePrefab, obstacleSpawnPosition, obstacleSpawnRotation);

        //    // Set any additional properties or behaviors for the obstacle

        //    // Set the obstacle as a child of the spawner for organization
        //    obstacle.transform.parent = transform;
        //}

        for (int i = 0; i < collectiblesPerGroup; i++)
        {

            Vector3 collectibleSpawnPosition = new Vector3(0, 1.5f, lastGroupPosition + i * 2f);
            Instantiate(collectiblePrefab, collectibleSpawnPosition, Quaternion.identity);
        }

        lastGroupPosition += groupDistance;
    }
}

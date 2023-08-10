using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject fenceFront;
    [SerializeField]
    GameObject fenceMiddle;
    [SerializeField]
    GameObject cubeStack;

    int biomeLength;
    int j = -5;

    Vector3 currentSpawnPosition;


    void Start()
    {
        currentSpawnPosition = new Vector3(0, 1.65f, 0);

        for (int i = 0; i < 20; i++)
        {
            GameObject.Instantiate(cubeStack, new Vector3(1, 0, j), Quaternion.Euler(0, 0, 0));
            j += 15;
        }
        GenerateLevelStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateLevelStart()
    {
        SetBiomeLength();
        for (int i = 0; i < biomeLength; i++)
        {
            if (i == 0)
            {
                GameObject.Instantiate(fenceFront, currentSpawnPosition, Quaternion.Euler(0, 90, 0));
                currentSpawnPosition.z += 3.75f;
            }

            if (i > 0)
            {
                GameObject.Instantiate(fenceMiddle, currentSpawnPosition, Quaternion.Euler(0, 90, 0));
                currentSpawnPosition.z += 3.75f;
            }
        }

    }

    void SetBiomeLength()
    {
        biomeLength = Random.Range(3, 8);
    }
}

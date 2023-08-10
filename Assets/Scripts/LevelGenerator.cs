using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject fenceFront;
    [SerializeField]
    GameObject fenceMiddle;

    int biomeLength;

    Vector3 currentSpawnPosition;


    void Start()
    {
        currentSpawnPosition = new Vector3(0, 0, 0);
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
                GameObject.Instantiate(fenceFront, currentSpawnPosition, Quaternion.Euler(0, 0, 0));
                currentSpawnPosition.x -= 3.75f;
            }

            if (i > 0)
            {
                GameObject.Instantiate(fenceMiddle, currentSpawnPosition, Quaternion.Euler(0, 0, 0));
                currentSpawnPosition.x -= 3.75f;
            }
        }

    }

    void SetBiomeLength()
    {
        biomeLength = Random.Range(3, 8);
    }
}

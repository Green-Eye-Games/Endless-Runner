using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject plane;
    private void OnDestroy()
    {
        GameObject.Instantiate(plane, new Vector3(0, 0, transform.position.z + 600), Quaternion.Euler(0, 0, 0));
    }
}

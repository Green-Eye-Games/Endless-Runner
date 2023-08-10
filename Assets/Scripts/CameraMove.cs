using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    // Update is called once per frame

    private TestPlayer _player;

    private void Start()
    {
        _player = FindObjectOfType<TestPlayer>();
    }

    void Update()
    {
        moveSpeed = _player._forwardSpeed;

        transform.Translate(Vector3.forward * moveSpeed *Time.deltaTime, Space.World);
    }
}

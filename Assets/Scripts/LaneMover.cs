using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMover : MonoBehaviour
{
    TestPlayer _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<TestPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, _player._forwardSpeed) * Time.deltaTime);
    }
}

using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    private GameInput _input;
    private CharacterController _characterController;
    [SerializeField]
    private float _leftRightSpeed;
    [SerializeField]
    private float _forwardSpeed;
    [SerializeField]
    private float _gravity;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = new GameInput();
        _input.Enable();
    }


    // Update is called once per frame
    void Update()
    {
        MoveLeftRight();
        ApplyGravity();
        MoveForward();
    }

    private void MoveLeftRight()
    {
        float movement = _input.Player.Move.ReadValue<float>();
        var direction = transform.right * movement;
        var velocity = direction * _leftRightSpeed;
        _characterController.Move(velocity * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        _characterController.Move(new Vector3(0, -_gravity, 0) * Time.deltaTime);
    }

    private void MoveForward()
    {
        _characterController.Move(new Vector3(0, 0, _forwardSpeed) * Time.deltaTime);
    }

}

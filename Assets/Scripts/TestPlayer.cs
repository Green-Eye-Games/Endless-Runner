using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPlayer : MonoBehaviour
{
    private GameInput _input;

    [SerializeField]
    private float _leftRightSpeed;
    [SerializeField]
    private float _forwardSpeed;
    [SerializeField]
    private float _jumpSpeed;

    Rigidbody rb;

    private float _canJump = -1;
    private float _jumpRate = 2.0f;

    [SerializeField]
    Transform leftLane;
    [SerializeField]
    Transform middleLane;
    [SerializeField]
    Transform rightLane;

    void Start()
    {
        _input = new GameInput();
        _input.Enable();
        _input.Player.Jump.performed += Jump_performed;
        _input.Player.Move.performed += Move_performed;
        rb = GetComponent<Rigidbody>();

        transform.position = middleLane.position;
    }

    private void Move_performed(InputAction.CallbackContext obj)
    { 
        if(obj.ReadValue<float>() == -1)
        {
            if(transform.position == rightLane.position)
            {
                transform.position = middleLane.position;
            }
            else if (transform.position == middleLane.position)
            {
                transform.position = leftLane.position;
            }
            else if(transform.position == leftLane.position)
            {
                return;
            }
        }
        else if(obj.ReadValue<float>() == 1)
        {
            if (transform.position == leftLane.position)
            {
                transform.position = middleLane.position;
            }
            else if (transform.position == middleLane.position)
            {
                transform.position = rightLane.position;
            }
            else if (transform.position == rightLane.position)
            {
                return;
            }
        }
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        if (Time.time > _canJump)
        {
            _canJump = Time.time + _jumpRate;
            rb.AddForce(new Vector3(0, _jumpSpeed, 0), ForceMode.Impulse);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, 0, _forwardSpeed) * Time.deltaTime);
    }
}

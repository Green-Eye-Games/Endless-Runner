using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEditorInternal;

public class TestPlayer : MonoBehaviour
{
    public enum LaneState
    {
        left,
        middle,
        right
    }

    public LaneState laneState;

    private GameInput _input;

    [SerializeField]
    private float _leftRightSpeed;
    
    public float _forwardSpeed;
    [SerializeField]
    private float _jumpSpeed;

    Rigidbody rb;

    private float _canJump = -1;
    private float _jumpRate = 2.0f;


    void Start()
    {
        _input = new GameInput();
        _input.Enable();
        _input.Player.Jump.performed += Jump_performed;
        _input.Player.Move.performed += Move_performed;
        rb = GetComponent<Rigidbody>();

        laneState = LaneState.middle;
        
    }

    private void Move_performed(InputAction.CallbackContext obj)
    { 
        if(obj.ReadValue<float>() == -1)
        {
            if(laneState == LaneState.right)
            {
                laneState = LaneState.middle;
            }
            else if(laneState == LaneState.middle) 
            {
                laneState = LaneState.left;
            }
            else if(laneState == LaneState.left)
            {
                return;
            }
        }
        else if(obj.ReadValue<float>() == 1)
        {
            if (laneState == LaneState.left)
            {
                laneState = LaneState.middle;
            }
            else if (laneState == LaneState.middle)
            {
                laneState = LaneState.right;
            }
            else if(laneState== LaneState.right)
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
        switch (laneState)
        {
            case LaneState.left:
                transform.position = Vector3.Lerp(transform.position, new Vector3(-4.6f, transform.position.y, transform.position.z), 0.025f);
                break;
            case LaneState.right:
                transform.position = Vector3.Lerp(transform.position, new Vector3(4.6f, transform.position.y, transform.position.z), 0.025f);
                break;
            case LaneState.middle:
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 0.025f);
                break;
        }

    }
}

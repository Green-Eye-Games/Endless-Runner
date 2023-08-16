using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEditorInternal;

public class Player : MonoBehaviour
{
    public enum LaneState
    {
        left,
        middle,
        right
    }

    public LaneState laneState;

    private GameInput _input;
    
    public float _forwardSpeed;

    [SerializeField]
    private float _jumpSpeed;
    [SerializeField]
    private float _gravity;

    Rigidbody rb;
    Animator _anim;
    CapsuleCollider col;
    private float _canJump = -1;
    private float _jumpRate = 2.0f;


    void Start()
    {
        _input = new GameInput();
        _input.Enable();
        _input.Player.Jump.performed += Jump_performed;
        _input.Player.Move.performed += Move_performed;
        rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
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
            _anim.SetTrigger("Jump");
            _canJump = Time.time + _jumpRate;
            rb.AddForce(new Vector3(0, _jumpSpeed, 0), ForceMode.Impulse);

            StartCoroutine(SizeCollider());
        }
    }

    IEnumerator SizeCollider()
    {
        col.height = 1;
        yield return new WaitForSeconds(0.75f);
        col.height = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.y != 0.05555487f)
        {
            rb.velocity -= new Vector3(rb.velocity.x, _gravity, rb.velocity.z) * Time.deltaTime;
        }
        

    }

    private void Move()
    {
        transform.Translate(new Vector3(0, 0, _forwardSpeed) * Time.deltaTime);
        switch (laneState)
        {
            case LaneState.left:
                transform.position = Vector3.Lerp(transform.position, new Vector3(-3.03f, transform.position.y, transform.position.z), 0.025f);
                break;
            case LaneState.right:
                transform.position = Vector3.Lerp(transform.position, new Vector3(3.03f, transform.position.y, transform.position.z), 0.025f);
                break;
            case LaneState.middle:
                transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 0.025f);
                break;
        }

    }
}

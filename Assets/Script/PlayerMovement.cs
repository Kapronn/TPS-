using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5;
    private CharacterController _characterController;
    private float _horizontalInput, _verticalInput;
    private Vector3 _direction;

    [Header("Grounding")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float sphereToGround;
    private Vector3 _spherePosition;

    [Header("Gravity")]
    [SerializeField] private float gravity = -9.81f;
    private Vector3 _velocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        CreateDirectionOfMovement();
        Gravity();
    }

    private void CreateDirectionOfMovement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _direction = transform.forward * _verticalInput + transform.right * _horizontalInput;
        _characterController.Move(_direction * (Time.deltaTime * moveSpeed));
    }

    bool IsGrounded()
    {
        _spherePosition = new Vector3(transform.position.x, transform.position.y - sphereToGround, transform.position.z);
        if (Physics.CheckSphere(_spherePosition, _characterController.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity()            
    {
        if (!IsGrounded()) _velocity.y += gravity * Time.deltaTime;
        else if (_velocity.y < 0) _velocity.y = -2;

        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_spherePosition, _characterController.radius -0.05f);
        
    }
}
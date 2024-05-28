using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float reduceMovementDivisor = 2f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckRadius = 0.2f;

    private Vector3 _moveDirection = Vector3.zero;
    private float _currentMoveSpeed = 0f;
    private MovementType _movementType = MovementType.Walk;
    private bool _isGrounded = false;
    private float _verticalVelocity = 0f;

    private void Start()
    {
        _currentMoveSpeed = movementSpeed;
    }

    private void Update()
    {
        IsGrounded();

        MovePlayer();
    }

    public void SetMovement(Vector3 input)
    {
        // Set direction
        _moveDirection = input;

        // Calculate movement speed depending on direction
        GetSpeedByDirection();
    }

    public void SetMovementType(MovementType type)
    {
        // Set movement type (walk, run, etc.)
        _movementType = type;

        // Calculate movement speed depending on movement type
        GetSpeedByDirection();
    }

    private void IsGrounded()
    {
        Vector3 groundCheckPosition = transform.position - new Vector3(0f, characterController.height / 2);
        _isGrounded = Physics.CheckSphere(groundCheckPosition, groundCheckRadius, groundMask);
    }

    private void MovePlayer()
    {
        Vector3 movement = transform.right * _moveDirection.x + transform.forward * _moveDirection.z;

        characterController.Move(movement.normalized * (_currentMoveSpeed * Time.deltaTime)
            + new Vector3(0f, _verticalVelocity, 0f) * Time.deltaTime);
    }

    // If character is moving forward, use full speed. Else, reduced.
    private void GetSpeedByDirection()
    {
        if (_moveDirection.z > 0f)
            _currentMoveSpeed = movementSpeed * _movementType.GetMovementSpeed();
        else 
            _currentMoveSpeed = (movementSpeed / reduceMovementDivisor) * _movementType.GetMovementSpeed();
    }
}

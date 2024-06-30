using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float reduceMovementDivisor = 2f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float gravity = -15.0f;
    [SerializeField] private float terminalVelocity = 53.0f;

    private Vector3 _moveDirection = Vector3.zero;
    private float _currentMoveSpeed = 0f;
    private bool _isGrounded = false;
    private float _verticalVelocity = 0f;

    private void OnEnable()
    {
        playerController.OnMovementInput += SetMovement;
        playerController.OnJumpInput += Jump;
    }

    private void OnDisable()
    {
        playerController.OnMovementInput -= SetMovement;
        playerController.OnJumpInput -= Jump;
    }

    private void Start()
    {
        _currentMoveSpeed = movementSpeed;
    }

    private void Update()
    {
        IsGrounded();
        ApplyGravity();

        if (playerController.CanPlayerDoActions())
            MovePlayer();
    }

    public void SetMovement(Vector2 input)
    {
        // Set direction
        _moveDirection = new Vector3(input.x, 0f, input.y);

        // Calculate movement speed depending on direction
        GetSpeedByDirection();
    }

    private void IsGrounded()
    {
        Vector3 groundCheckPosition = transform.position - new Vector3(0f, characterController.height / 2);
        _isGrounded = Physics.CheckSphere(groundCheckPosition, groundCheckRadius, groundMask);
    }

    private void ApplyGravity()
    {
        // Apply gravity if player is in the air
        if (!_isGrounded && _verticalVelocity < terminalVelocity)
            _verticalVelocity += gravity * Time.deltaTime;
    }

    private void MovePlayer()
    {
        Vector3 movement = transform.right * _moveDirection.x + transform.forward * _moveDirection.z;

        characterController.Move(movement.normalized * (_currentMoveSpeed * Time.deltaTime)
            + new Vector3(0f, _verticalVelocity, 0f) * Time.deltaTime);
    }

    // If character is moving straight forward, use full speed. Else, reduced.
    private void GetSpeedByDirection()
    {
        if (_moveDirection.z > 0f && _moveDirection.x == 0)
            _currentMoveSpeed = movementSpeed;
        else 
            _currentMoveSpeed = movementSpeed / reduceMovementDivisor;
    }

    public void Jump()
    {
        Debug.Log("Jump executed");
        if (_isGrounded)
            _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}

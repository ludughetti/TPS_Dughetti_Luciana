using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerView playerView;

    private void OnEnable()
    {
        inputReader.OnMovementInput += HandleMovementInput;
        inputReader.OnMovementTypeChangeInput += HandleMovementTypeChangeInput;
    }

    private void OnDisable()
    {
        inputReader.OnMovementInput -= HandleMovementInput;
        inputReader.OnMovementTypeChangeInput -= HandleMovementTypeChangeInput;
    }

    private void HandleMovementInput(Vector2 input)
    {
        playerMovement.SetMovement(new Vector3(input.x, 0f, input.y));
        playerView.SetMovementDirection(input);
    }

    private void HandleMovementTypeChangeInput(MovementType type)
    {
        playerMovement.SetMovementType(type);
        playerView.SetMovementType(type);
    }
}

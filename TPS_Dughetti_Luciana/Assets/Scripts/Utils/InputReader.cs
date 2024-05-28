using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> OnMovementInput = delegate { };
    public event Action<MovementType> OnMovementTypeChangeInput = delegate { };

    public void HandleMovementInput(InputAction.CallbackContext context)
    {
        OnMovementInput.Invoke(context.ReadValue<Vector2>());
    }

    public void HandleSprintToggleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"{name}: Sprint triggered.");
            OnMovementTypeChangeInput.Invoke(MovementType.Run);
        } else if (context.canceled)
        {
            Debug.Log($"{name}: Sprint trigger finished, returning to Walk.");
            OnMovementTypeChangeInput.Invoke(MovementType.Walk);
        }
    }
}

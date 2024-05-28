using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    public event Action<Vector2> OnMovementInput = delegate { };
    public event Action<MovementType> OnMovementTypeChangeInput = delegate { };
    public event Action<bool> OnAimInput = delegate { };
    public event Action<bool> OnAttackInput = delegate { };

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

    public void HandleAimInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log($"{name}: Aim triggered.");
            OnAimInput.Invoke(true);
        } else if (context.canceled)
        {
            Debug.Log($"{name}: Aim trigger finished, returning to Idle.");
            OnAimInput.Invoke(false);
        }
    }

    public void HandleAttackInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"{name}: Attack triggered.");
            OnAttackInput.Invoke(true);
        }
        else if (context.canceled)
        {
            Debug.Log($"{name}: Attack trigger finished, returning to Idle or Aim.");
            OnAttackInput.Invoke(false);
        }
    }
}

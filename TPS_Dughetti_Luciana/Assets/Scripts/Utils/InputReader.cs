using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public void HandleMovementInput(InputAction.CallbackContext context)
    {
        playerController.HandleMovementInput(context.ReadValue<Vector2>());
    }

    public void HandleSprintToggleInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"{name}: Sprint triggered.");
            playerController.HandleMovementTypeChangeInput(MovementType.Run);
        } else if (context.canceled)
        {
            Debug.Log($"{name}: Sprint trigger finished, returning to Walk.");
            playerController.HandleMovementTypeChangeInput(MovementType.Walk);
        }
    }

    public void HandleAimInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log($"{name}: Aim triggered.");
            playerController.HandleAimInput(true);
        } else if (context.canceled)
        {
            Debug.Log($"{name}: Aim trigger finished, returning to Idle.");
            playerController.HandleAimInput(false);
        }
    }

    public void HandleAttackInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log($"{name}: Attack triggered.");
            playerController.HandleAttackInput(true);
        }
        else if (context.canceled)
        {
            Debug.Log($"{name}: Attack trigger finished, returning to Idle or Aim.");
            playerController.HandleAttackInput(false);
        }
    }

    public void HandleMeleeWeaponInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log($"{name}: Changing to melee weapon.");
            playerController.HandleWeaponChange(WeaponType.Melee);
        }
    }

    public void HandlePistolWeaponInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log($"{name}: Changing to pistol weapon.");
            playerController.HandleWeaponChange(WeaponType.Pistol);
        }
    }

    public void HandleRifleWeaponInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log($"{name}: Changing to rifle weapon.");
            playerController.HandleWeaponChange(WeaponType.Rifle);
        }
    }
}

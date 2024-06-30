using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public void HandleMovementInput(InputAction.CallbackContext context)
    {
        playerController.HandleMovementInput(context.ReadValue<Vector2>());
    }

    public void HandleMouseInput(InputAction.CallbackContext context)
    {
        playerController.HandleMouseInput(context.ReadValue<Vector2>());
    }

    public void HandleAimInput(InputAction.CallbackContext context)
    {
        if(context.started)
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
        if (context.started)
        {
            Debug.Log($"{name}: Attack triggered.");
            playerController.HandleAttackInput();
        }
    }

    public void HandleMeleeWeaponInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log($"{name}: Changing to melee weapon.");
            playerController.HandleWeaponChange((int) WeaponType.Melee);
        }
    }

    public void HandlePistolWeaponInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log($"{name}: Changing to pistol weapon.");
            playerController.HandleWeaponChange((int) WeaponType.Pistol);
        }
    }

    public void HandleRifleWeaponInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log($"{name}: Changing to rifle weapon.");
            playerController.HandleWeaponChange((int) WeaponType.Rifle);
        }
    }

    public void HandleJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log($"{name}: Jump triggered");
            playerController.HandleJumpInput();
        }
    }
}

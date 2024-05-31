using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerCombat playerCombat;

    public event Action<Vector2> OnMovementInput = delegate { };
    public event Action<MovementType> OnMovementTypeChangeInput = delegate { };
    public event Action<WeaponType> OnWeaponChangeInput = delegate { };
    public event Action<bool> OnAimInput = delegate { };
    public event Action<bool> OnAttackInput = delegate { };

    public void HandleMovementInput(Vector2 input)
    {
        OnMovementInput.Invoke(input);
    }

    public void HandleMovementTypeChangeInput(MovementType type)
    {
        OnMovementTypeChangeInput.Invoke(type);
    }

    public void HandleAimInput(bool isAiming)
    {
        OnAimInput.Invoke(isAiming);
    }

    public void HandleAttackInput(bool isAttacking)
    {
        OnAttackInput.Invoke(isAttacking);
    }

    public void HandleWeaponChange(WeaponType weapon)
    {
        if (playerCombat.CanSwitchWeapon(weapon))
            OnWeaponChangeInput.Invoke(weapon);
    }
}

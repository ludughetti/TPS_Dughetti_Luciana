using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerCombat playerCombat;

    public event Action<Vector2> OnMovementInput = delegate { };
    public event Action<Vector2> OnMouseInput = delegate { };
    public event Action<MovementType> OnMovementTypeChangeInput = delegate { };
    public event Action<int> OnWeaponChangeInput = delegate { };
    public event Action<bool> OnAimInput = delegate { };
    public event Action OnAttackInput = delegate { };

    private bool _canPlayerDoActions = true;

    public void HandleMovementInput(Vector2 input)
    {
        if(_canPlayerDoActions)
            OnMovementInput.Invoke(input);
    }
    public void HandleMouseInput(Vector2 input)
    {
        OnMouseInput.Invoke(input);
    }

    public void HandleMovementTypeChangeInput(MovementType type)
    {
        if (_canPlayerDoActions)
            OnMovementTypeChangeInput.Invoke(type);
    }

    public void HandleAimInput(bool isAiming)
    {
        if (_canPlayerDoActions)
            OnAimInput.Invoke(isAiming);
    }

    public void HandleAttackInput()
    {
        if (_canPlayerDoActions)
            OnAttackInput.Invoke();
    }

    public void HandleWeaponChange(int index)
    {
        if (_canPlayerDoActions && playerCombat.CanSwitchWeapon(index))
            OnWeaponChangeInput.Invoke(index);
    }

    public bool CanPlayerDoActions()
    {
        return _canPlayerDoActions;
    }

    public void ToggleCanPlayerDoActions(bool canPlayerDoActions)
    {
        _canPlayerDoActions = canPlayerDoActions;
    }
}

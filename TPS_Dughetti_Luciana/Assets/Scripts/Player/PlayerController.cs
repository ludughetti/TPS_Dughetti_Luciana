using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private CharacterHealth characterHealth;

    public event Action<Vector2> OnMovementInput = delegate { };
    public event Action<Vector2> OnMouseInput = delegate { };
    public event Action<int> OnWeaponChangeInput = delegate { };
    public event Action<bool> OnAimInput = delegate { };
    public event Action OnAttackInput = delegate { };
    public event Action OnJumpInput = delegate { };

    private bool _canPlayerDoActions = true;

    private void OnEnable()
    {
        characterHealth.OnDeath += TriggerEndgameOnDeath;
    }

    private void OnDisable()
    {
        characterHealth.OnDeath -= TriggerEndgameOnDeath;
    }

    public void HandleMovementInput(Vector2 input)
    {
        if(_canPlayerDoActions)
            OnMovementInput.Invoke(input);
    }

    public void HandleMouseInput(Vector2 input)
    {
        OnMouseInput.Invoke(input);
    }

    public void HandleAimInput(bool isAiming)
    {
        if (_canPlayerDoActions && playerCombat.CanAim())
            OnAimInput.Invoke(isAiming);
    }

    public void HandleAttackInput()
    {
        if (_canPlayerDoActions)
            OnAttackInput.Invoke();
    }

    public void HandleWeaponChange(int index)
    {
        if (_canPlayerDoActions)
        {
           int activeWeapon = playerCombat.SwitchWeapon(index);
           OnWeaponChangeInput.Invoke(activeWeapon);
        }
    }
    public void HandleJumpInput()
    {
        if(_canPlayerDoActions)
            OnJumpInput.Invoke();
    }

    public bool CanPlayerDoActions()
    {
        return _canPlayerDoActions;
    }

    public void ToggleCanPlayerDoActions(bool canPlayerDoActions)
    {
        _canPlayerDoActions = canPlayerDoActions;
    }

    private void TriggerEndgameOnDeath()
    {
        StartCoroutine(TriggerEndgame());
    }

    private IEnumerator TriggerEndgame()
    {
        yield return new WaitForSeconds(4);
        gameController.TriggerEndgameScreen(false);
    }
}
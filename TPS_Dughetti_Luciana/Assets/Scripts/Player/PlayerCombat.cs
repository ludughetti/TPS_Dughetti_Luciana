using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private List<Weapon> weapons;

    private Weapon _activeWeapon;

    private void OnEnable()
    {
        _activeWeapon = weapons[0];

        playerController.OnWeaponChangeInput += SwitchWeapon;
        playerController.OnAttackInput += Attack;
    }

    private void OnDisable()
    {
        playerController.OnWeaponChangeInput -= SwitchWeapon;
        playerController.OnAttackInput -= Attack;
    }

    public void SwitchWeapon(int index)
    {
        Debug.Log($"Old weapon is {_activeWeapon}, new weapon is {weapons[index - 1]}");

        _activeWeapon.TogglePrefab(false);
        _activeWeapon = weapons[index - 1];
        _activeWeapon.TogglePrefab(true);
    }

    public void Attack()
    {
        _activeWeapon.Attack();

        // Block movement until attack is finished
        if (_activeWeapon.DoAttackPause())
            playerController.ToggleCanPlayerDoActions(false);
    }

    public void Aim()
    {
        _activeWeapon.Aim();
    }

    public bool CanSwitchWeapon(int weaponIndex)
    {
        return _activeWeapon.GetIndex() != weaponIndex;
    }
}

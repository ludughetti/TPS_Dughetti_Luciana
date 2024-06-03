using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LayerMask enemy;
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

    public bool CanSwitchWeapon(int weaponIndex)
    {
        return _activeWeapon.GetIndex() != weaponIndex;
    }

    public void SwitchWeapon(int index)
    {
        Debug.Log($"Old weapon is {_activeWeapon}, new weapon is {weapons[index - 1]}");

        _activeWeapon.TogglePrefab(false);
        _activeWeapon = weapons[index - 1];
        _activeWeapon.TogglePrefab(true);
    }

    public void Aim()
    {
        _activeWeapon.Aim();
    }

    public void Attack()
    {
        // Block movement until attack is finished
        if (_activeWeapon.DoAttackPause())
            playerController.ToggleCanPlayerDoActions(false);

        Debug.Log("Combat attack triggered");
        _activeWeapon.Attack(enemy, out var targetHit);

        Debug.Log("Combat damage enemy triggered");
        if (targetHit != null)
            DamageEnemy(targetHit);
    }

    private void DamageEnemy(GameObject targetHit)
    {
        if (targetHit.TryGetComponent<CharacterHealth>(out var targetHealth))
            targetHealth.TakeDamage(_activeWeapon.GetWeaponDamage());
    }
}

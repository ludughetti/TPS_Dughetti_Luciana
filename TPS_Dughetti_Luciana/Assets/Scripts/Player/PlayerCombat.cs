using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Transform cameraTarget;

    private Weapon _activeWeapon;
    private Weapon _unarmedWeapon;

    private void OnEnable()
    {
        _unarmedWeapon = weapons[0];
        _activeWeapon = _unarmedWeapon;

        playerController.OnAttackInput += Attack;
    }

    private void OnDisable()
    {
        playerController.OnAttackInput -= Attack;
    }

    public int GetWeaponIndex(int weaponIndex)
    {
        return _activeWeapon.GetIndex() == weaponIndex ? _unarmedWeapon.GetIndex() : weaponIndex;
    }

    public int SwitchWeapon(int index)
    {
        Debug.Log($"Switch Weapon received. Index: {index}");
        _activeWeapon = _activeWeapon.GetIndex() == index
            ? _unarmedWeapon
            : weapons[index];

        return _activeWeapon.GetIndex();
    }

    public bool CanAim()
    {
        return _activeWeapon.HasRangedAttack();
    }

    public void Aim()
    {
        _activeWeapon.Aim();
    }

    public bool IsPointingAtEnemy()
    {
        return Physics.Raycast(cameraTarget.position, cameraTarget.forward, Mathf.Infinity, enemy);
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

    public void ToggleWeaponVisibility(int index, bool isWeaponVisible)
    {
        Debug.Log($"Toggle Weapon Visibility received. Index: {index}, isWeaponVisible: {isWeaponVisible}");
        weapons[index].TogglePrefab(isWeaponVisible);
    }
}

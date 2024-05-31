using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private WeaponType _activeWeapon = WeaponType.Melee;

    private void OnEnable()
    {
        playerController.OnWeaponChangeInput += SwitchWeapon;
        playerController.OnAttackInput += Attack;
    }

    private void OnDisable()
    {
        playerController.OnWeaponChangeInput -= SwitchWeapon;
        playerController.OnAttackInput -= Attack;
    }

    public void SwitchWeapon(WeaponType weapon)
    {
        Debug.Log($"Old weapon is {_activeWeapon}, new weapon is {weapon}");
        _activeWeapon = weapon;
    }

    public void Attack(bool isAttacking)
    {
        Debug.Log("Attack!");
    }

    public bool CanSwitchWeapon(WeaponType weapon)
    {
        return _activeWeapon != weapon;
    }
}

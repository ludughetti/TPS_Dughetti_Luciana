using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] private int maxAmmo = 100;
    [SerializeField] private Transform barrelEnd;
    [SerializeField] private Transform aimTarget;

    private int _currentAmmo = 0;

    private void Awake()
    {
        _currentAmmo = maxAmmo;
    }

    public override void Attack(LayerMask target, out GameObject targetHit)
    {
        Debug.Log($"Shoot!");
        if (_currentCooldown > 0f)
        {
            Debug.Log($"{name}: Weapon still in cooldown ({_currentCooldown})");

            targetHit = null;
            return;
        } else if (_currentAmmo == 0)
        {
            Debug.Log($"{name}: Weapon has no ammo ({_currentAmmo})");

            targetHit = null;
            return;
        }

        _currentAmmo--;
        weaponAudio.PlayAttackSound();

        TriggerWeaponCooldown();
        if (Physics.Raycast(barrelEnd.position, aimTarget.forward, out RaycastHit hit, range, target))
        {
            Debug.Log($"{name}: target {hit.transform.name} hit");
            Debug.DrawRay(barrelEnd.position, barrelEnd.forward * range, Color.yellow, 2);

            targetHit = hit.transform.gameObject;
        }
        else
        {
            Debug.DrawRay(barrelEnd.position, aimTarget.forward * range, Color.white, 2);
            targetHit = null;
        }
    }

    public override bool HasRangedAttack()
    {
        return true;
    }

    public override void Aim()
    {
        Debug.Log($"Aim!");
    }

    public override void AddAmmo(int amount)
    {
        _currentAmmo += amount;
        Debug.Log($"{name}: Added {amount} ammo. Current amount: {_currentAmmo}");
    }
}

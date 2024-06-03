using UnityEngine;

public class RangeWeapon : Weapon
{
    public override void Attack(LayerMask target, out GameObject targetHit)
    {
        Debug.Log($"Shoot!");
        if (_currentCooldown > 0f)
        {
            Debug.Log($"Weapon still in cooldown: {_currentCooldown}");

            targetHit = null;
            return;
        }

        TriggerWeaponCooldown();
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range, target))
        {
            Debug.Log($"{name}: target {hit.transform.name} hit");
            Debug.DrawRay(transform.position, transform.forward * hit.point.magnitude, Color.yellow, 2);
            //OnWeaponAttack.Invoke(hit.point);

            targetHit = hit.transform.gameObject;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * range, Color.white, 2);
            //OnWeaponAttack.Invoke(transform.forward * GetWeaponRange());
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
}

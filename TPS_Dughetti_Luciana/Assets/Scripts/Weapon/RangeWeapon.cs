using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] private float range = 10f;

    public override void Attack()
    {
        Debug.Log($"Shoot!");
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

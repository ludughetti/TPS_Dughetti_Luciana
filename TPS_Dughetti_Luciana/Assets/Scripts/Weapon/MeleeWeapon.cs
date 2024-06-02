using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float damageRadius = 2f;

    public override void Attack()
    {
        Debug.Log($"Attack!");
    }
}

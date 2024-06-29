using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float damageRadius = 0.1f;

    public override void Attack(LayerMask target, out GameObject targetHit)
    {
        Debug.Log("Melee attack triggered");

        if (_currentCooldown > 0f)
        {
            Debug.Log($"Weapon still in cooldown: {_currentCooldown}");

            targetHit = null;
            return;
        }

        _currentCooldown = cooldown;

        if (Physics.SphereCast(transform.position, damageRadius, transform.forward, out var hit, range, target))
        {
            Debug.Log($"{name}: Enemy {hit.transform.gameObject.name} was hit");

            targetHit = hit.transform.gameObject;
            targetHit.GetComponent<CharacterHealth>().TakeDamage(damage);

            return;
        }

        targetHit = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, damageRadius);

        Vector3 center = transform.position + new Vector3(0f, 0f, range);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, damageRadius);
    }
}

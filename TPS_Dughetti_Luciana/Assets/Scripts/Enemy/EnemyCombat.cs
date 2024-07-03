using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private Weapon weapon;
    [SerializeField] protected LayerMask target;
    [SerializeField] private ParticleSystem areaOfEffect;

    private bool _hasTargetInAttackRange = false;

    private void OnEnable()
    {
        enemyController.OnAttack += Attack;
    }

    private void OnDisable()
    {
        enemyController.OnAttack -= Attack;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{name}: player found");
            _hasTargetInAttackRange = true;

            if (!weapon.IsInCooldown())
                enemyController.TriggerAttack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_hasTargetInAttackRange && !weapon.IsInCooldown()
                && other.CompareTag("Player"))
            enemyController.TriggerAttack();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _hasTargetInAttackRange = false;
    }

    private void Attack()
    {
        weapon.Attack(target, out GameObject targetHit);

        if (areaOfEffect != null)
            areaOfEffect.Play();
    }
}

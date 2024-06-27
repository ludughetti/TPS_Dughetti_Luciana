using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private Weapon weapon;
    [SerializeField] protected LayerMask target;

    private bool _hasTargetInAttackRange = false;
    private float _currentAttackCooldown = 0f;

    private void OnEnable()
    {
        enemyController.OnAttack += Attack;
    }

    private void OnDisable()
    {
        enemyController.OnAttack -= Attack;
    }

    private void Update()
    {
        if (IsAttackOnCooldown())
            _currentAttackCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"{name}: player found");
            _hasTargetInAttackRange = true;

            if (!IsAttackOnCooldown())
                enemyController.TriggerAttack();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_hasTargetInAttackRange && !IsAttackOnCooldown()
                && other.CompareTag("Player"))
            enemyController.TriggerAttack();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _hasTargetInAttackRange = false;
    }

    private bool IsAttackOnCooldown()
    {
        return _currentAttackCooldown > 0f;
    }

    private void Attack()
    {
        weapon.Attack(target, out GameObject targetHit);
    }
}

using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private CharacterHealth health;
    [SerializeField] private Weapon weapon;
    [SerializeField] private string isWalkingParam = "isRunning";
    [SerializeField] private string isDeadParam = "isDead";
    [SerializeField] private string attackAnimation = "isAttacking";

    private void OnEnable()
    {
        health.OnDeath += TriggerDeathAnimation;
        enemyController.OnAttack += TriggerAttackAnimation;
    }

    private void OnDisable()
    {
        health.OnDeath -= TriggerDeathAnimation;
        enemyController.OnAttack -= TriggerAttackAnimation;
    }

    private void Update()
    {
        animator.SetBool(isWalkingParam, enemyController.IsRunning());
    }

    public void TriggerDeathAnimation()
    {
        animator.SetBool(isDeadParam, true);
    }

    public void TriggerAttackAnimation()
    {
        animator.SetBool(attackAnimation, true);
    }

    public void EndAttackAnimation()
    {
        animator.SetBool(attackAnimation, false);
        enemyController.CanMove(true);
    }
}

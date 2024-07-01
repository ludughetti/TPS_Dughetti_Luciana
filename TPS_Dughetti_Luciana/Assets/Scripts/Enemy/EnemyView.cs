using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private CharacterHealth health;
    [SerializeField] private Weapon weapon;
    [SerializeField] private string isWalkingParam = "isRunning";
    [SerializeField] private string isDeadParam = "isDead";
    [SerializeField] private string attackAnimation = "Attack";

    private void OnEnable()
    {
        health.OnDeath += TriggerDeathAnimation;
        enemyController.OnAttack += PlayAttackAnimation;
    }

    private void OnDisable()
    {
        health.OnDeath -= TriggerDeathAnimation;
        enemyController.OnAttack -= PlayAttackAnimation;
    }

    private void Update()
    {
        animator.SetBool(isWalkingParam, enemyController.IsRunning());
    }

    public void TriggerDeathAnimation()
    {
        //animator.Play(deathAnimation);
        animator.SetBool(isDeadParam, true);
    }

    public void PlayAttackAnimation()
    {
        animator.Play(attackAnimation);
    }
}

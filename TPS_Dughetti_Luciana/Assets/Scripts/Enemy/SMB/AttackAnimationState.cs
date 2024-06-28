using UnityEngine;

public class AttackAnimationState : StateMachineBehaviour
{
    private EnemyController _enemyController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnAttackAnimEnter");
        if (_enemyController == null)
            _enemyController = animator.GetComponentInParent<EnemyController>();

        _enemyController.CanMove(false);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnAttackAnimExit");
        if (_enemyController == null)
            _enemyController = animator.GetComponentInParent<EnemyController>();

        _enemyController.CanMove(true);
    }
}

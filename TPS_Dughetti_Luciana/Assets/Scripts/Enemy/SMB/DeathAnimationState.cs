using UnityEngine;

public class DeathAnimationState : StateMachineBehaviour
{
    private EnemyController _enemyController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnDeathAnimEnter");
        if (_enemyController == null)
            _enemyController = animator.GetComponentInParent<EnemyController>();

        _enemyController.CanMove(false);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnDeathAnimExit");
        if (_enemyController == null)
            _enemyController = animator.GetComponentInParent<EnemyController>();

        _enemyController.RemoveCharacterOnDeath();
    }
}

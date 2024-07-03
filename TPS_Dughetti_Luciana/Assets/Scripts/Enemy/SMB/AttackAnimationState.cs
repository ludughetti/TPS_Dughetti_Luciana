using UnityEngine;

public class AttackAnimationState : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnAttackAnimEnter");
        EnemyView enemyView = animator.GetComponentInParent<EnemyView>();

        if (enemyView != null)
            enemyView.EndAttackAnimation();
    }
}

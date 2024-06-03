using UnityEngine;

public class MeleeAttackBehavior : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log($"{name}: Attack animation over, reenabling player movement");
        animator.GetComponentInParent<PlayerView>().EnableMovementAfterAttack();
    }
}

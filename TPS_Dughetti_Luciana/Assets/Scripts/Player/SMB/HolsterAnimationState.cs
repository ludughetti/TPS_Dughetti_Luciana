using UnityEngine;

public class HolsterAnimationState : StateMachineBehaviour
{
    private PlayerView _playerView;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnHolsterAnimExit");
        if(_playerView == null)
            _playerView = animator.GetComponentInParent<PlayerView>();

        _playerView.ShowWeaponOnDraw();
    }
}

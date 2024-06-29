using UnityEngine;

public class DrawAnimationState : StateMachineBehaviour
{
    private PlayerView _playerView;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("OnDrawAnimEnter");
        if (_playerView == null)
            _playerView = animator.GetComponentInParent<PlayerView>();

        _playerView.HideWeaponOnHolster();
    }
}

using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private CharacterHealth characterHealth;
    [SerializeField] private float animationSpeed = 4f;
    [SerializeField] private string moveSpeedParam = "move_speed";
    [SerializeField] private string directionXParam = "dir_x";
    [SerializeField] private string directionZParam = "dir_z";
    [SerializeField] private string isAimingParam = "is_aiming";
    [SerializeField] private string attackParam = "attack";
    [SerializeField] private string weaponTypeParam = "weapon_type";
    [SerializeField] private string isDeadParam = "is_dead";

    private int _currentWeaponId = 0;
    private int _nextWeaponId = 0;
    private Vector2 _currentDirection = Vector2.zero;
    private Vector2 _nextDirection = Vector2.zero;
    private Vector2 _previousDirection = Vector2.zero;

    private void OnEnable()
    {
        playerController.OnMovementInput += SetMovementDirection;
        playerController.OnAimInput += SetIsAiming;
        playerController.OnWeaponChangeInput += ChangeWeapon;
        playerController.OnAttackInput += TriggerAttack;
        characterHealth.OnDeath += SetIsDead;
    }

    private void OnDisable()
    {
        playerController.OnMovementInput -= SetMovementDirection;
        playerController.OnAimInput -= SetIsAiming;
        playerController.OnWeaponChangeInput -= ChangeWeapon;
        playerController.OnAttackInput -= TriggerAttack;
        characterHealth.OnDeath -= SetIsDead;
    }

    private void Update()
    {
        SmoothAnimationTransitions();
        SetMovementAnimations();
    }

    public void SetMovementDirection(Vector2 input)
    {
        _nextDirection = input;
    }

    public void SetIsAiming(bool isAiming)
    {
        animator.SetBool(isAimingParam, isAiming);
    }

    public void TriggerAttack()
    {
        animator.SetBool(attackParam, true);
    }

    public void EnableMovementAfterAttack()
    {
        playerController.ToggleCanPlayerDoActions(true);
    }

    private void SetMovementAnimations()
    {
        animator.SetFloat(moveSpeedParam, _currentDirection.magnitude);
        animator.SetFloat(directionXParam, _currentDirection.x);
        animator.SetFloat(directionZParam, _currentDirection.y);
    }

    private void ChangeWeapon(int index)
    {
        _nextWeaponId = index;
        animator.SetInteger(weaponTypeParam, index);
    }

    private void SmoothAnimationTransitions()
    {
        SmoothMovementValues(ref _nextDirection.x, ref _previousDirection.x, ref _currentDirection.x);
        SmoothMovementValues(ref _nextDirection.y, ref _previousDirection.y, ref _currentDirection.y);
    }

    /*
     * This method lerps input(X,Y) values between changes to smooth animation transitions.
     * If a change comes from a negative position (e.g. [-1,0]) to a positive one (e.g. [1,0]), 
     * then the current position needs to be increased.
     * However, if a change comes from a positive position (e.g. [1,0]) to a negative one (e.g. [-1,0]), 
     * then the current position needs to be decreased.
     * 
     * _previousDirection will be updated once _currentInput reaches _nextDirection's values 
     * (AKA the actual input value provided by InputReader).
     * 
     * This is calculated both for input.x as well as input.y.
     */
    private void SmoothMovementValues(ref float nextValue, ref float previousValue, ref float currentValue)
    {

        // Lerp on X depending in which direction we're moving
        if (nextValue > previousValue)
        {
            currentValue += Time.deltaTime * animationSpeed;
            currentValue = Mathf.Clamp(currentValue, previousValue, nextValue);
            if (currentValue >= nextValue)
                previousValue = nextValue;
        }
        else if (nextValue < previousValue)
        {
            currentValue -= Time.deltaTime * animationSpeed;
            currentValue = Mathf.Clamp(currentValue, nextValue, previousValue);
            if (currentValue <= nextValue)
                previousValue = nextValue;
        }
    }

    public void HideWeaponOnHolster()
    {
        Debug.Log($"Hide weapon on holster received. Current weapon: {_currentWeaponId}, next weapon: {_nextWeaponId}");
        playerCombat.ToggleWeaponVisibility(_currentWeaponId, false);
    }

    public void ShowWeaponOnDraw()
    {
        Debug.Log($"Show weapon on draw received. Current weapon: {_currentWeaponId}, next weapon: {_nextWeaponId}");
        playerCombat.ToggleWeaponVisibility(_nextWeaponId, true);
        _currentWeaponId = _nextWeaponId;
    }

    public void SetIsDead()
    {
        animator.SetBool(isDeadParam, true);
    }
}

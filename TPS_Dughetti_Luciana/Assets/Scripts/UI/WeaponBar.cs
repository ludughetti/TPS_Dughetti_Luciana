using UnityEngine;

public class WeaponBar : MonoBehaviour
{
    [SerializeField] private WeaponIcon meleeIcon;
    [SerializeField] private WeaponIcon pistolIcon;
    [SerializeField] private WeaponIcon rifleIcon;
    [SerializeField] private PlayerController playerController;

    private WeaponIcon _activeWeaponIcon;

    private void OnEnable()
    {
        playerController.OnWeaponChangeInput += ChangeWeaponIconActive;
    }

    private void OnDisable()
    {
        playerController.OnWeaponChangeInput -= ChangeWeaponIconActive;
    }

    private void ChangeWeaponIconActive(int index)
    {
        if(_activeWeaponIcon != null)
            _activeWeaponIcon.ToggleActive(false);

        switch(index)
        {
            case 1:
                _activeWeaponIcon = meleeIcon;
                break;
            case 2:
                _activeWeaponIcon = pistolIcon;
                break;
            case 3:
                _activeWeaponIcon = rifleIcon;
                break;
            default:
                _activeWeaponIcon = null;
                break;
        }

        if(_activeWeaponIcon != null)
            _activeWeaponIcon.ToggleActive(true);


    }
}

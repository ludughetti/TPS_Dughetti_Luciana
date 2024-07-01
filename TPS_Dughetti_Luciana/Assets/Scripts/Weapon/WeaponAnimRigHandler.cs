using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponAnimRigHandler : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    //[SerializeField] private RigBuilder rigBuilder;
    [SerializeField] private List<WeaponAnimRig> weaponRigs;

    private WeaponAnimRig _activeRig;

    private void OnEnable()
    {
        playerController.OnWeaponChangeInput += ChangeRigOnWeaponInput;
    }

    private void OnDisable()
    {
        playerController.OnWeaponChangeInput -= ChangeRigOnWeaponInput;
    }

    private void ChangeRigOnWeaponInput(int index)
    {
        foreach(WeaponAnimRig weaponRig in weaponRigs)
        {
            if(weaponRig.GetWeaponIndex() == index)
            {
                if(_activeRig != null)
                    _activeRig.ToggleRig(false);

                _activeRig = weaponRig;
                _activeRig.ToggleRig(true);

                break;
            }
        }

        if (_activeRig != null && _activeRig.GetWeaponIndex() != index)
            Debug.Log($"{name}: Weapon {index} has no animRig");
    }
}

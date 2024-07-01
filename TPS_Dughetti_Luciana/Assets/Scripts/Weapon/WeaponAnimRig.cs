using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponAnimRig : MonoBehaviour
{
    [SerializeField] private Rig rig;

    private int _index = 0;

    private void Awake()
    {
        rig.weight = 0f;

        if (TryGetComponent<Weapon>(out var weapon))
            _index = (int) weapon.GetWeaponType();

        Debug.Log($"{name}: WeaponAnimRig index is {_index}");
    }

    public int GetWeaponIndex()
    {
        return _index;
    }

    public void ToggleRig(bool enableRig)
    {
        rig.weight = enableRig ? 1 : 0;
    }
}

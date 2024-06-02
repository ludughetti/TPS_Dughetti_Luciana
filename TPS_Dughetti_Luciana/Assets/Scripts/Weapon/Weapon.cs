using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] protected WeaponType type;
    [SerializeField] protected float damage = 20f;
    [SerializeField] protected float cooldown = 1f;
    [SerializeField] protected bool doAttackPause = false;

    private int _index;

    private void Start()
    {
        _index = (int) type;
    }

    public WeaponType GetWeaponType()
    {
        return type;
    }

    public int GetIndex() 
    { 
        return _index; 
    }

    public void TogglePrefab(bool showPrefab)
    {
        weaponPrefab.SetActive(showPrefab);
    }

    public bool DoAttackPause()
    {
        return doAttackPause;
    }

    public virtual void Attack()
    {
        Debug.Log($"{name}: Attack not implemented for base Weapon class");
    }

    public virtual bool HasRangedAttack()
    {
        Debug.Log($"{name}: HasRangedAttack not implemented for base Weapon class");
        return false;
    }

    public virtual void Aim()
    {
        Debug.Log($"{name}: Aim not implemented for base Weapon class");
    }
}

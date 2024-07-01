using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] protected WeaponType type;
    [SerializeField] protected WeaponAudio weaponAudio;
    [SerializeField] protected float damage = 20f;
    [SerializeField] protected float cooldown = 1f;
    [SerializeField] protected float range = 10f;
    [SerializeField] protected bool doAttackPause = false;

    private int _index;
    protected float _currentCooldown = 0f;

    private void Start()
    {
        _index = (int) type;
    }

    private void Update()
    {
        if (_currentCooldown > 0f)
            _currentCooldown -= Time.deltaTime;
    }

    public WeaponType GetWeaponType()
    {
        return type;
    }

    public float GetWeaponDamage()
    {
        return damage;
    }

    public int GetIndex() 
    { 
        return _index; 
    }

    public void TogglePrefab(bool showPrefab)
    {
        if(weaponPrefab != null)
            weaponPrefab.SetActive(showPrefab);
    }

    public bool DoAttackPause()
    {
        return doAttackPause;
    }
    
    public bool IsInCooldown()
    {
        return _currentCooldown <= 0f;
    }

    public virtual void Attack(LayerMask target, out GameObject targetHit)
    {
        Debug.Log($"{name}: Attack not implemented for base Weapon class");
        targetHit = null;
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

    protected void TriggerWeaponCooldown()
    {
        _currentCooldown = cooldown;
    }

    public virtual void AddAmmo(int amount)
    {
        Debug.Log($"{name}: AddAmmo not implemented for base Weapon class");
    }

    public virtual int GetAmmoCount()
    {
        Debug.Log($"{name}: GetAmmoCount not implemented for base Weapon class");
        return 0;
    }
}

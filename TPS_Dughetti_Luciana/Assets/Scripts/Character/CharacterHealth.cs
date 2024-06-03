using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    private float _health;

    private void OnEnable()
    {
        _health = maxHealth;
    }

    [ContextMenu("TakeDamage")]
    public void MockTakeDamage()
    {
        TakeDamage(10f);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{name}: {damage} damage received");
        _health -= damage;
    }

    public float GetCurrentHealth()
    {
        return _health;
    }
}

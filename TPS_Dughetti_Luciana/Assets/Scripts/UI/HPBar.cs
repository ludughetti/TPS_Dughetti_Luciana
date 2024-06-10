using UnityEngine;

public class HPBar : SliderBar
{
    [SerializeField] private CharacterHealth characterHealth;

    private void Start()
    {
        _currentValue = characterHealth.GetMaxHealth();
        sliderBar.value = _currentValue;
        sliderBar.maxValue = _currentValue;
        text.text = _currentValue.ToString();
    }

    private void OnEnable()
    {
        characterHealth.OnHeal += UpdateBarOnHealthChange;
        characterHealth.OnDamageTaken += UpdateBarOnHealthChange;
        characterHealth.OnDeath += UpdateBarValueOnDeath;
    }

    private void OnDisable()
    {
        characterHealth.OnHeal -= UpdateBarOnHealthChange;
        characterHealth.OnDamageTaken -= UpdateBarOnHealthChange;
        characterHealth.OnDeath -= UpdateBarValueOnDeath;
    }

    private void UpdateBarOnHealthChange(float currentHP)
    {
        _currentValue = currentHP;
    }

    private void UpdateBarValueOnDeath()
    {
        _currentValue = 0f;
    }
}

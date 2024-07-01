using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    [SerializeField] private Image activeIcon;

    private Color _activeColor = Color.green;
    private Color _inactiveColor = Color.red;

    private void Start()
    {
        activeIcon.color = _inactiveColor;
    }

    public void ToggleActive(bool active)
    {
        activeIcon.color = active ? _activeColor : _inactiveColor;
    }
}

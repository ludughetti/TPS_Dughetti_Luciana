using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private PlayerCombat playerCombat;
    [SerializeField] private RawImage crosshairIcon;
    [SerializeField] private Color normalCrosshair;
    [SerializeField] private Color atEnemyCrosshair;

    private void Update()
    {
        UpdateCrosshairOnEnemySight();
    }

    private void UpdateCrosshairOnEnemySight()
    {
        if (playerCombat.IsPointingAtEnemy())
            crosshairIcon.color = atEnemyCrosshair;
        else
            crosshairIcon.color = normalCrosshair;
    }
}

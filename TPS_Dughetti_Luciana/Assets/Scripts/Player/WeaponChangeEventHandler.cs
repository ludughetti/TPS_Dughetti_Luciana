using UnityEngine;

public class WeaponChangeHandler : MonoBehaviour
{
    [SerializeField] private PlayerView playerView;

    public void HideWeaponOnHolster()
    {
        playerView.HideWeaponOnHolster();
    }

    public void ShowWeaponOnDraw()
    {
        playerView.ShowWeaponOnDraw();
    }
}

using UnityEngine;

public class AmmoPack : PickUpItem
{
    [SerializeField] private int ammoAmount = 10;

    protected override void DoAction(GameObject player)
    {
        Debug.Log($"{name}: Player picked up an ammo pack, they will gain {ammoAmount} bullets");
        
        PlayerCombat playerCombat = player.GetComponentInChildren<PlayerCombat>();

        if (playerCombat != null)
            playerCombat.AddAmmoToAllRangedWeapons(ammoAmount);
    }
}

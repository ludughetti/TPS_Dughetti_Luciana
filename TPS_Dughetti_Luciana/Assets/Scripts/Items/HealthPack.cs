using UnityEngine;

public class HealthPack : PickUpItem
{
    [SerializeField] private float healAmount = 10f;

    protected override void DoAction(GameObject player)
    {
        Debug.Log($"{name}: Player picked up a health pack, they will heal for {healAmount}");
        if (!player.TryGetComponent<CharacterHealth>(out var playerHealth))
            return;

        playerHealth.Heal(healAmount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private PickUpItemType spawnerType;
    [SerializeField] private GameObject item;
    [SerializeField] private float itemCooldown = 10f;

    private float _itemCooldown = 0f;

    private void Update()
    {
        if (_itemCooldown > 0f)
            _itemCooldown -= Time.deltaTime;
        else if (!item.activeSelf)
            IsItemAvailable(true);
    }

    public void IsItemAvailable(bool isActive)
    {
        Debug.Log($"{name}: Spawner IsItemAvailable triggered. Item is active? {item.activeSelf}. Cooldown is {_itemCooldown}");
        if (!isActive)
            _itemCooldown = itemCooldown;

        item.SetActive(isActive);
    }
}

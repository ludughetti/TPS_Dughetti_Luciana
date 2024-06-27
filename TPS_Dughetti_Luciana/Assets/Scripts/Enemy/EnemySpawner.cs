using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnArea;
    [SerializeField] private Transform spawns;
    [SerializeField] private Transform target;
    //[SerializeField] private GameController gameController;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnCooldown = 5f;
    [SerializeField] private int maxActiveSpawns = 5;

    private float _spawnCooldown = 0f;
    private int _activeSpawns = 0;

    private void Update()
    {
        if (_spawnCooldown <= 0f && _activeSpawns < maxActiveSpawns)
        {
            Debug.Log($"{name}: Spawned enemy");
            _spawnCooldown = spawnCooldown;
            SpawnEnemy();
        }
        else if (_spawnCooldown > 0)
        {
            _spawnCooldown -= Time.deltaTime;
        }
    }

    [ContextMenu("Spawn")]
    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnArea.position, Quaternion.identity, spawns);
        EnemyController controller = enemy.GetComponent<EnemyController>();
        controller.SetPlayer(target);
        controller.SetSpawner(this);

        _activeSpawns++;
    }

    public void RemoveActiveSpawn()
    {
        _activeSpawns--;
        //gameController.AddKillToCounter();
    }
}

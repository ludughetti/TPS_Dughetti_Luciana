using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    public Action OnAttack = delegate { };

    private Transform _player;
    private EnemySpawner _spawner;
    private bool _isRunning = true;

    void Update()
    {
        agent.SetDestination(_player.position);
    }

    public bool IsRunning()
    {
        return _isRunning;
    }

    public void CanMove(bool canMove)
    {
        agent.speed = canMove ? 2f : 0f;
        _isRunning = canMove;
    }

    public void RemoveCharacterOnDeath()
    {
        Debug.Log($"{name}: Enemy dead");
        _spawner.RemoveActiveSpawn();

        Destroy(gameObject);
    }

    public void SetPlayer(Transform player)
    {
        _player = player;
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        _spawner = spawner;
    }

    public virtual void TriggerAttack()
    {
        OnAttack.Invoke();
    }
}

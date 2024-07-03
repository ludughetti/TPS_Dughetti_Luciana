using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CharacterHealth enemyHealth;

    public Action OnAttack = delegate { };

    private Transform _player;
    private EnemySpawner _spawner;
    private bool _isRunning = true;
    private bool _isDead = false;

    private void OnEnable()
    {
        enemyHealth.OnDeath += DisableOnDeath;
    }

    private void OnDisable()
    {
        enemyHealth.OnDeath -= DisableOnDeath;
    }

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

    private IEnumerator RemoveCharacterOnDeath()
    {
        yield return new WaitForSeconds(3);
        Debug.Log($"{name}: Enemy dead");
        gameObject.SetActive(false);
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
        if (!_isDead)
        {
            CanMove(false);
            OnAttack.Invoke();
        }
    }

    private void DisableOnDeath()
    {
        _isDead = true;
        CanMove(false);
        StartCoroutine(RemoveCharacterOnDeath());
    }
}

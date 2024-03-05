using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints;
    [SerializeField] private Player player;
    [SerializeField] private float viewAngle;
    [SerializeField] private float damage = 30;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerDetected;
    private Health _playerHealth;
    
    void Start()
    {
        InitializeComponents();
        PickupNewPatrolPoint();
    }

    private void InitializeComponents()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<Health>();
    }
    
    void Update()
    {
        if (player != null)
        {
            DetectPlayer();
            FollowPlayer();
            Attack();
        }
        PatrolUpdate();
    }

    private void DetectPlayer()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerDetected = false;

        bool isInFieldOfView = Vector3.Angle(transform.forward, direction) < viewAngle;

        if (!isInFieldOfView)
            return;

        RaycastHit hit;
        var isHit = Physics.Raycast(transform.position + Vector3.up, direction, out hit);
        if (isHit && hit.collider.transform.root.gameObject == player.gameObject)
            _isPlayerDetected = true;
    }

    private void FollowPlayer()
    {
        if (_isPlayerDetected)
            _navMeshAgent.destination = player.transform.position;
    }

    private void Attack()
    {
        if (_isPlayerDetected && _navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _playerHealth.SubtractHealth(damage * Time.deltaTime);
        }
    }
    private void PatrolUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_isPlayerDetected)
            PickupNewPatrolPoint();
    }

    private void PickupNewPatrolPoint() =>
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent), typeof(Health))]
public class EnemyStates : MonoBehaviour
{
    [SerializeField] private List<Transform> patrolPoints;
    [SerializeField] private float viewAngle = 90;
    [SerializeField] private int damage = 30;
    [SerializeField] private float attackDistance = 2;
    public static int enemyCount;
    
    private NavMeshAgent _navMeshAgent;
    private Player _player;
    private State _currentState;
    private Animator _animator;
    private static readonly int IsReachedPlayer = Animator.StringToHash("IsReachedPlayer");

    private void Awake()
    {
        _player = GetComponent<Player>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>(true);
        EventBus.DealDamage += Attack;
        _currentState = new PatrolState();
        enemyCount += 1;
    }

    private void Update()
    {
        _currentState?.Tick(this);
    }

    private void OnDisable()
    {
        EventBus.DealDamage -= Attack;
        enemyCount -= 1;
    }

    private Vector3 PickPatrolPoint() => patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    
    private bool IsPlayerDetected()
    {
        if (!_player) return false;

        Vector3 direction = _player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) >= viewAngle) return false;

        if (!Physics.Raycast(transform.position + Vector3.up, direction, out var hit)) return false;

        return hit.transform.root.gameObject == _player.gameObject;
    }

    private void Attack()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= attackDistance) 
            EventBus.OnTookDamage?.Invoke(damage);
    }

    private void SwitchState(State to)
    {
        _currentState.OnExit(this);
        _currentState = to;
        _currentState.OnEnter(this);
    }
    private abstract class State
    {
        public abstract void OnEnter(EnemyStates enemy);
        public abstract void Tick(EnemyStates enemy);
        public abstract void OnExit(EnemyStates enemy);
    }
    
    private class PatrolState : State
    {
        public override void OnEnter(EnemyStates enemy)
        {
            enemy._navMeshAgent.SetDestination(enemy.PickPatrolPoint());
        }

        public override void Tick(EnemyStates enemy)
        {
            if (!enemy._navMeshAgent.hasPath)
                enemy._navMeshAgent.SetDestination(enemy.PickPatrolPoint());
            if (enemy.IsPlayerDetected())
                enemy.SwitchState(new ChaseState());
        }

        public override void OnExit(EnemyStates enemy)
        {
            enemy._navMeshAgent.ResetPath();
        }
    }
    
    private class ChaseState : State
    {
        public override void OnEnter(EnemyStates enemy) { }

        public override void Tick(EnemyStates enemy)
        {
            if (enemy._player == null) enemy.SwitchState(new PatrolState());
            enemy._navMeshAgent.destination = enemy._player.transform.position;
            if (!enemy.IsPlayerDetected())
                enemy.SwitchState(new PatrolState());
            else if (Vector3.Distance(enemy.transform.position, enemy._player.transform.position) < enemy.attackDistance)
                enemy.SwitchState(new AttackState());
        }

        public override void OnExit(EnemyStates enemy)
        {
            enemy._navMeshAgent.ResetPath();
        }
    }
    
    private class AttackState : State
    {
        public override void OnEnter(EnemyStates enemy) { }

        public override void Tick(EnemyStates enemy)
        {
            if (enemy._player == null) enemy.SwitchState(new PatrolState());
            if (Vector3.Distance(enemy.transform.position, enemy._player.transform.position) <= enemy.attackDistance)
            {
                enemy._animator.SetTrigger(IsReachedPlayer);
            }
            else enemy.SwitchState(new ChaseState());
        }

        public override void OnExit(EnemyStates enemy) { }
    }
}

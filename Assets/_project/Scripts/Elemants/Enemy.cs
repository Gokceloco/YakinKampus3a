using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Rigidbody _rb;
    private NavMeshAgent _agent;
    private Player _player;
    private Transform _transform;
    private Animator _animator;

    public int startHealth;
    private int _curHealth;

    private HealthBar _healthBar;

    public EnemyState enemyState;

    public float enemySightRange;
    public float attackRange;

    public Collider aliveCollider;
    public Collider deadCollider;

    public float flashDuration;

    public List<Renderer> bodyRenderers;
    public List<Renderer> clothRenderers;

    public Material flashMaterial;
    public Material bodyMaterial;
    public Material clothMaterial;

    private Coroutine _flashCoroutine;

    private void Start()
    {
        _transform = transform;
        _curHealth = startHealth;
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        _player = GameDirector.instance.player;
        _healthBar = GetComponentInChildren<HealthBar>();
        _healthBar.SetHealthRatio(1);
        _animator = GetComponentInChildren<Animator>();
        _animator.SetFloat("CycleOffset", Random.Range(0f,1f));
    }

    private void Update()
    {
        if (enemyState == EnemyState.Dead)
        {
            return;
        }
        var distanceVector = _player.transform.position - _transform.position;
        var distance = distanceVector.magnitude;
        if (distance < attackRange)
        {
            if (enemyState != EnemyState.Attacking)
            {
                enemyState = EnemyState.Attacking;
                _animator.SetTrigger("Attack");
                _agent.isStopped = true;
            }   
        }
        else if (distance < enemySightRange && enemyState != EnemyState.Moving)
        {
            if (Physics.Raycast(_transform.position + Vector3.up, distanceVector.normalized, out var hit, distance)
                && hit.transform.CompareTag("Player"))
            {
                enemyState = EnemyState.Moving;
                _animator.SetTrigger("Walk");
                GameDirector.instance.audioManager.PlayZombieAttackSFX();
                _agent.isStopped = false;
            }
        }

        if (enemyState == EnemyState.Moving)
        {
            _agent.SetDestination(_player.transform.position);
        }
    }

    public void GetHit(int damage)
    {
        _curHealth -= damage;

        if (_flashCoroutine != null)
        {
            StopCoroutine(_flashCoroutine);
        }
        _flashCoroutine = StartCoroutine(FlashCoroutine());

        _healthBar.SetHealthRatio((float)_curHealth / startHealth);
        if (_curHealth <= 0 && enemyState != EnemyState.Dead)
        {
            Die();
        }
    }

    IEnumerator FlashCoroutine()
    {
        foreach (var r in bodyRenderers)
        {
            r.material = flashMaterial;
        }
        foreach (var r in clothRenderers)
        {
            r.material = flashMaterial;
        }
        _agent.isStopped = true;

        yield return new WaitForSeconds(flashDuration);

        foreach (var r in bodyRenderers)
        {
            r.material = bodyMaterial;
        }
        foreach (var r in clothRenderers)
        {
            r.material = clothMaterial;
        }
        if (enemyState != EnemyState.Dead)
        {
            _agent.isStopped = false;
        }
    }

    private void Die()
    {
        if (Random.value < .5f)
        {
            _animator.SetTrigger("FallBack1");
        }
        else
        {
            _animator.SetTrigger("FallBack2");
        }
        _agent.isStopped = true;
        enemyState = EnemyState.Dead;
        aliveCollider.enabled = false;
        deadCollider.enabled = true;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        Invoke(nameof(DisposeBody), 3f);
    }

    void DisposeBody()
    {
        deadCollider.enabled = false;
        _agent.enabled = false;
        Destroy(gameObject, 1f);
    }
}

public enum EnemyState
{
    Idle,
    Moving,
    Attacking,
    Dead,
}
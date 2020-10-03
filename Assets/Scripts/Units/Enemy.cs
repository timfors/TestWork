using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{

    public WayPoints waypoints;

    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private int _damage = 0,
        _reward = 0;

    [SerializeField, Range(1, 2)]
    private float _healthScale = 1,
        _damageScale = 1,
        _rewardScale = 1;

    void Start()
    {
        Init();
        StartCoroutine(Moving());
    }

    public void Restart()
    {
        Init();
    }
    private void Init()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _health = (int)(_health * Mathf.Pow(_healthScale, WaveController.WaveCount - 1));
        _reward = (int)(_reward * Mathf.Pow(_rewardScale, WaveController.WaveCount - 1));
        _damage = (int)(_damage * Mathf.Pow(_damageScale, WaveController.WaveCount - 1));
    }
    

    private IEnumerator Moving()
    {
        Transform target = waypoints.GetWayPoint(0);
        _navMeshAgent.SetDestination(target.position);
        //this lets NavMesh update his remainingDistance, without this it'll be 0
        yield return null;
        int nextPointIndex = 1;
        while(nextPointIndex < waypoints.GetPointsCount())
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                target = waypoints.GetWayPoint(nextPointIndex);
                _navMeshAgent.SetDestination(target.position);
                nextPointIndex++;
            }
            yield return null;
        }
    }
    public void Clear() => Destroy(gameObject);
    private void Damage(Player target)
    {
        target.TakeDamage(_damage);
    }
    protected override void Die()
    {
        StopAllCoroutines();
        FindObjectOfType<WaveController>().CountKill(_reward);
        Gold.Add(_reward);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Player target = collision.collider.GetComponent<Player>();
            Damage(target);
            Die();
        }
    }


}

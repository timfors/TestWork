using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{
    public List<Enemy> availableTargets = new List<Enemy>();

    [SerializeField]
    private int _startDamage = 0;

    [SerializeField]
    private float _startAttackSpeed = 0;


    public float StartAttackSpeed { get { return _startAttackSpeed; } }
    public int StartDamage { get { return _startDamage; } }
        

    public int damage = 0,
        rank = 1;   

    public float attackSpeed = 0;


    [SerializeField]
    private Enemy _target = null;

    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(WaitingTarget());
    }

    private IEnumerator AttackTarget()
    {
        while(_target != null)
        {
            _animator.Play("Attack");
            Damage(_target);
            yield return new WaitForSeconds(1 / attackSpeed);
        }
    }
    private IEnumerator WaitingTarget()
    {
        while (true)
        {
            if (availableTargets.Count > 0)
            {
                if (availableTargets[0] == null)
                    availableTargets.RemoveAt(0);
                else
                {
                    _target = availableTargets[0] ?? null;
                    yield return StartCoroutine(AttackTarget());
                }
            }
            yield return null;
        }
    }
    private void Damage(Enemy target)
    {
        target.TakeDamage(damage);
    }


}

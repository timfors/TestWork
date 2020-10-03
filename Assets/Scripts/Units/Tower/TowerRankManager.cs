using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRankManager : MonoBehaviour
{
    [SerializeField]
    private Tower _tower = null;

    [SerializeField]
    private TextMesh _upgradeText = null;


    [SerializeField, Range(1, 3)]
    private float _damageScale = 1,
        _upgradeCostScale = 1,
        _attackSpeedScale = 1;

    [SerializeField]
    private int _startUpgradeCost = 0;
    private int _upgradeCost = 0;

    [SerializeField]
    private Animator _anim = null;
    private void Start()
    {
        SetRank(1);
    }
    private void OnMouseDown()
    {
        TryUpgrade();
    }

    public void SetRank(int rank)
    {
        _tower.rank = rank;
        _tower.attackSpeed = _tower.StartAttackSpeed * Mathf.Pow(_attackSpeedScale, _tower.rank - 1);
        _tower.damage = (int)(_tower.StartDamage * Mathf.Pow(_damageScale, _tower.rank - 1));
        _upgradeCost = (int)(_startUpgradeCost * Mathf.Pow(_upgradeCostScale, _tower.rank - 1));
        _upgradeText.text = _upgradeCost.ToString();
        _anim.SetFloat("Speed", _tower.attackSpeed / _tower.StartAttackSpeed);
    }
    public void TryUpgrade()
    {
        if (Gold.TrySpend(_upgradeCost))
        {
            SetRank(_tower.rank + 1);
        }
    }

    public void Restart()
    {
        SetRank(0);
    }

}

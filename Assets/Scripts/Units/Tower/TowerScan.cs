using UnityEngine;
using System.Collections.Generic;

public class TowerScan : MonoBehaviour
{
    [SerializeField]
    private Tower tower = null;


    private void OnTriggerEnter(Collider other)
    {
        Enemy newTarget = other.GetComponent<Enemy>();
        if (!tower.availableTargets.Contains(newTarget))
            tower.availableTargets.Add(newTarget);
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy lostTarget = other.GetComponent<Enemy>();
        if (tower.availableTargets.Contains(lostTarget))
            tower.availableTargets.Remove(lostTarget);
    }
}

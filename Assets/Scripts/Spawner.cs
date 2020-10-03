using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectCreate = null;

    [SerializeField]
    private WayPoints waypoints = null;

    [SerializeField]
    private float _timeBetweenSpawn = 0;

    private bool isSpawning = false;
    public void StartSpawn(int count)
    {
        isSpawning = true;
        StartCoroutine(Spawning(count));
    }

    public void StopSpawn()
    {
        isSpawning = false;
    }
    private IEnumerator Spawning(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (!isSpawning)
                yield break;
            GameObject enemy = Instantiate(_objectCreate, transform.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().waypoints = waypoints;
            yield return new WaitForSeconds(_timeBetweenSpawn);
        }
    }
}

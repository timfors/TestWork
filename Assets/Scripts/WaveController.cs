using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private int _activeEnemyCount = 0;

    [SerializeField]
    private int _extraEnemy= 1;

    [SerializeField]
    private List<Spawner> _enemySpawnerList = null;

    private Config _config = new Config();
    public static int EnemyKillCount { get; private set; } = 0;
    public static WaveController Instance { get; private set; } = null;


    static public int WaveCount { get; private set; } = 0;

    public static bool IsPlay { get; private set; } = true;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        var configFile = Resources.Load("config");
        _config = JsonUtility.FromJson<Config>(configFile.ToString());
        Init();
    }
    public void CountKill(int reward)
    {
        _activeEnemyCount--;
        EnemyKillCount++;
    }

    public void Restart()
    {
        Init();
    }
    private  void Init()
    {
        WaveCount = 0;
        EnemyKillCount = 0;
        _activeEnemyCount = 0;
        Gold.SetAmount(0);
        StartGame();
    }

    public void StopGame()
    {
        IsPlay = false;
        foreach (Spawner spawner in _enemySpawnerList)
            spawner.StopSpawn();
    }

    public void StartGame()
    {
        IsPlay = true;
        StartCoroutine(WaveStarter());
    }

    private IEnumerator WaveStarter()
    {
        while (IsPlay)
        {
            if (_activeEnemyCount == 0)
            {
                WaveCount++;
                _activeEnemyCount = WaveCount + _extraEnemy;
                _activeEnemyCount *= _enemySpawnerList.Count;
                yield return new WaitForSeconds(_config.timeDelay);
                foreach (Spawner spawner in _enemySpawnerList)
                    spawner.StartSpawn(_activeEnemyCount);
            }
            yield return null;
        }
    }
}

using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] private Transform _spawnpoint;
    private EnemySpawner _enemySpawner;

    // 특정 간격 마다 보스 생성
    [SerializeField] private int _bossSpawnScoreInterval = 3000;
    private int _bossSpawnScore = 3000;
    private bool _isSpawnedBoss = false;

    private void Start()
    {
        _enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }

    private void Update()
    {
        CheckBoss();
    }

    private void CheckBoss()
    {
        if (_isSpawnedBoss)
            return;
        if (ScoreManager.Instance._score >= _bossSpawnScore)
        {
            bossSpawn();
        }
    }

    private void bossSpawn()
    {
        _isSpawnedBoss = true;
        // 일반 적 생성 그만
        _enemySpawner.StopSpawn();
        Instantiate(_bossPrefab, _spawnpoint.position, Quaternion.identity);
    }

    private void bossDead()
    {
        // 보스 재생성 가능하게
        _isSpawnedBoss = false;

        //보스 출현 수 확대
        _bossSpawnScore += _bossSpawnScoreInterval;

        // 일반적 생성 재개
        _enemySpawner.StartSpawn();
    }
}
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //필요속성
    // - 타이머
    [Header("스폰 간격")] [SerializeField] private float _spawninterval = 3f;
    private float _timer;

    //생성할 프리팹
    [Header("스폰할 적 프리팹")] [SerializeField] private Enemy _enemyPrefab;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawninterval)
        {
            _timer = 0;
            spawn();
        }
    }

    private void spawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab);
        enemy.transform.position = transform.position;
    }
}
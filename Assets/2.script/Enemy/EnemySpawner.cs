using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //필요속성
    // - 타이머
    [Header("스폰 간격")] [SerializeField] private float _spawninterval = 3f;
    private float _timer;

    // 뽑을 확률 설정
    private float[] _enemypercent = { 0.5f, 0.3f, 0.2f };

    //생성할 프리팹
    [Header("스폰할 적 프리팹")] [SerializeField] private Enemy[] _enemyPrefabs;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawninterval)
        {
            _timer = 0;

            _spawninterval = Random.Range(1f, 3f); // 1~3 초 사이 랜덤 배출

            RandomSpawn();
        }
    }

    // 09/04 실습 과제 2 확률에 따른 생성 및 플레이어가 존재할 때만 생성
//    private void spawn()
    //   {
    //      if (GameObject.FindGameObjectWithTag("Player") != null)
    //      {
    //          Enemy enemy = Instantiate(_enemyPrefab);
    //         enemy.transform.position = transform.position;
    //      }
    //  }

    // Todo: Scriptable Object를 이용해서 리팩토링
    // 이유: 배열을 사용했지만 각 아이템이 어떤 프리펩인지 알 수 없음
    // 이유2: 각 에너미 스폰 확률을 매직넘버로 하드코딩해서 유지보수가 어렵고 가독성 저하
    private void RandomSpawn()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            float _random = Random.Range(0f, 1f);
            int _randomEnemy = 0;
            if (_random < _enemypercent[0])
            {
                _randomEnemy = 0;
            }
            else if (_random < _enemypercent[0] + _enemypercent[1])
            {
                _randomEnemy = 1;
            }
            else
            {
                _randomEnemy = 2;
            }

            Enemy enemy = Instantiate(_enemyPrefabs[_randomEnemy]);
            enemy.transform.position = transform.position;
        }
    }
}
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //필요속성
    private GameObject _player;

    [SerializeField] private EnemySpawnDataTableSO _spawnDataTable;

    // - 타이머
    [Header("스폰 간격")] [SerializeField] private float _spawninterval = 3f;
    private float _timer;

    // 뽑을 확률 설정
    private float[] _enemypercent = { 0.5f, 0.3f, 0.2f };

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

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


    // Todo: Scriptable Object를 이용해서 리팩토링
    // 이유: 배열을 사용했지만 각 아이템이 어떤 프리펩인지 알 수 없음
    // 이유2: 각 에너미 스폰 확률을 매직넘버로 하드코딩해서 유지보수가 어렵고 가독성 저하
    private void RandomSpawn()
    {
        if (_player)
        {
            // 가중치 랜덤 선택(Weight)
            // 각 아이템에 가중치를 부여하고, 가중치를 클수록 높은 확률로 선택되도록 하는 방식
            // 가중치 기반 랜덤 선택 알고리즘

            // 1. 추천할 수 있는 모든 가중치를 더한다.
            int totalWeight = 0;
            foreach (EnemySpawnData data in _spawnDataTable.Datas)
            {
                totalWeight += data._weight;
            }

            // 2. 전체 가중치 범위에서 랜덤한 정수를 뽑는다.
            float randomWeight = Random.Range(0f, totalWeight);

            // 3. 가중치를 누적하면서 선택된 구간을 찾는다.
            int cumulativeWeight = 0;
            foreach (EnemySpawnData data in _spawnDataTable.Datas)
            {
                cumulativeWeight += data._weight;
                if (randomWeight < cumulativeWeight)
                {
                    GameObject enemy = Instantiate(data._enemyPrefab);
                    enemy.transform.position = transform.position;
                }

                return;
            }
        }
    }
}
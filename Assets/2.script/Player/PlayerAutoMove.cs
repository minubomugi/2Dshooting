using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    // 자동 이동 속도
    [Header("자동 이동 속도")] [SerializeField] private float _autoMoveSpeed = 5f;

    // 자동 이동 On/Off 확인용 아이
    private bool _autoMove = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _autoMove = !_autoMove;
        }

        if (_autoMove)
        {
            AutoMove(FindClosestEnemy());
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // 가장 가까이 오는 적으로 자동 이동
        GameObject closestEnemy = null;
        // 최대값 집어넣어서 거리 비교 예정
        float closeDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            //현재 탐지된 적들의 거리 구하기
            float distancetoenemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distancetoenemy < closeDistance)
            {
                closestEnemy = enemy;
                closeDistance = distancetoenemy;
            }
        }

        return closestEnemy;
    }

    // 자동 이동
    private void AutoMove(GameObject _enemy)
    {
        if (_enemy == null)
        {
            return;
        }

        Vector2 closestenemydirection = new Vector2(_enemy.transform.position.x - transform.position.x, 0f).normalized;
        transform.Translate(closestenemydirection * (_autoMoveSpeed * Time.deltaTime), Space.World);
    }
}
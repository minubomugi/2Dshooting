using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    // 자동 이동 속도
    [Header("자동 이동 속도")] [SerializeField] private float _autoMoveSpeed = 5f;

    // 적 탐지 범위
    //[Header("적 탐지 Y 범위")] [SerializeField] private float _detectRange = 2f;

    [SerializeField] private Animator _animator;

    //강사님 강의
    //[SerializeField] private float _speed = 100f;


    // 자동 이동 On/Off 확인용 아이
    private bool _autoMove = false;

    private void Awake()
    {
        // 애니메이터 컴포넌트에 대한 참조를 가져와서 할당한다.
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 1. 타겟을 구한다.
        //GameObject target = GameObject.FindWithTag("Enemy");
        //if (target != null) return;

        // 2. 방향을 구한다.
        //Vector3 direction = target.transform.position - transform.position;
        //direction.Normalize();
        //direction.y = 0;

        // 3. 속도에 맞게 이동한다.
        //transform.Translate(Vector3.forward * _autoMoveSpeed * Time.deltaTime);

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
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            // 탐지 범위 밖이면 무시
            //if (distanceToEnemy > _detectRange)
            //{
            //    continue;
            // }

            if (distanceToEnemy < closeDistance)
            {
                closestEnemy = enemy;
                closeDistance = distanceToEnemy;
            }
        }

        return closestEnemy;
    }

    // 자동 이동
    private void AutoMove(GameObject enemy)
    {
        if (enemy == null)
        {
            return;
        }

        // 적과 나의 위치 차이
        Vector2 diff = enemy.transform.position - transform.position;

        // x축은 적 방향 그대로
        Vector2 direction = diff;

        // 적과 y축 거리가 3 이상이면 위로
        // 3보다 작으면 아래로
        if (diff.y >= 3f)
        {
            direction.y = 1f;
        }
        else
        {
            direction.y = -1f;
        }

        direction.Normalize();

        // X축 이동 방향에 따라 애니메이션 변경
        if (direction.x > 0f)
        {
            _animator.SetInteger("x", 1);
        }
        else if (direction.x < 0f)
        {
            _animator.SetInteger("x", -1);
        }

        transform.Translate(direction * (_autoMoveSpeed * Time.deltaTime), Space.World);
    }
}
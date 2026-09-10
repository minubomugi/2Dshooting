using UnityEngine;

public class assignmnet0902 : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    [SerializeField] private float _limit;

    public float Limit
    {
        get { return _limit; }
    }

    // 애니메이터 참조
    [SerializeField] private Animator _animator;

    private PlayerAutoMove _playerAutoMove;

    //플레이 방식도 있는데, 얘는 애니메이션을 처음부터 자꾸 실행하려고 하는 문제점이 있다.

    //객체가 생성될 때 한 번 실행
    private void Awake()
    {
        // 애니메이터 컴포넌트에 대한 참조를 가져와서 할당한다.
        _animator = GetComponent<Animator>();
        _playerAutoMove = GetComponent<PlayerAutoMove>();
    }

    public float GetSpeed()
    {
        return _speed;
    }

    private void Update() //객체의 이벤트래
    {
        Move();
        SpeedChange(); // 콘텐츠 중심 명명법으로 짓는게 편해
        //InputSpeedKey() -> 옛날에 명령받아서 진행하는 입력받아 하는 기능중심 명명법
    }

    private void SpeedChange()
    {
        //실습 과제 3 e버튼 누르면 스피드 업, q버튼누르면 스피드 1다운
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _speed++;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            _speed--;
        }
    }

    private void Move()
    {
        //똑같이 이동할 수 있는 거 처리
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 nomalizedDirection = new Vector2(h, v).normalized;

        // 실제 입력이 있어야만 반응하는 시스템
        if (nomalizedDirection.x > 0f)
        {
            _animator.SetInteger("x", 1);
        }
        else if (nomalizedDirection.x < 0f)
        {
            _animator.SetInteger("x", -1);
        }
        else if (nomalizedDirection.x == 0f && !_playerAutoMove.isAutoMove)
        {
            _animator.SetInteger("x", 0);
        }

        //실습 과제 1,2 영역 제한 및 위치 이동
        float x = Mathf.Repeat(transform.position.x + _limit, _limit * 2f) - _limit;
        float y = Mathf.Clamp(transform.position.y, -_limit, _limit);

        transform.position = new Vector3(x, y, 0f);

        //이동
        transform.Translate(nomalizedDirection * (_speed * Time.deltaTime));
    }
}
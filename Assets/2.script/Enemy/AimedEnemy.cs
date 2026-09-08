using UnityEngine;

public class AimedEnemy : Enemy
{
    private GameObject _player;
    private Vector2 _direction;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        if (_player == null)
        {
            Debug.LogWarning("Player를 못 찾음");
            return;
        }

        //tan0 = dy/dx
        // tan^tan0 = tan^*dy/dx
        // tant^ dy*dx

        _direction = ((Vector2)_player.transform.position
                      - (Vector2)transform.position).normalized;

        float dx = _direction.x; // 플레이어와 적 사이의 밑변 길이
        float dy = _direction.y; // 플레이어와 적 사이의 높이 길이
        // 공식처럼 사용하는 수학 공식 암기하세용~
        float seta = Mathf.Atan2(dy, dx);
        // 얘는 라디안으로 나와줬기에 일반적으로 사용하는 각도를 위해서는 Rad2Deg를 곱해줘야함
        float angle = seta * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }

    protected override void Move()
    {
        transform.Translate(_direction * (_movespeed * Time.deltaTime), Space.World);

        //transform.position += (Vector3)(_direction * _movespeed) * Time.deltaTime;
    }
}
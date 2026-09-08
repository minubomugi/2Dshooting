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

        _direction = ((Vector2)_player.transform.position
                      - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }

    protected override void Move()
    {
        transform.Translate(_direction * (_movespeed * Time.deltaTime), Space.World);
    }
}
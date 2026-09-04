using UnityEngine;

public class AimedEnemy : Enemy
{
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Move()
    {
        if (_player == null) return;

        Vector2 direction = new Vector2(0, _player.transform.position.y - transform.position.y).normalized;
        transform.Translate(direction * (_movespeed * Time.deltaTime));
    }
}
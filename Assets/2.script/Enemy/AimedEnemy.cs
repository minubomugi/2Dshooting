using UnityEngine;

public class AimedEnemy : Enemy
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Move()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player == null)
        {
            Debug.LogWarning("Null값 보셈");
            return;
        }

        Vector2 direction = new Vector2(0, _player.transform.position.y - transform.position.y).normalized;
        transform.Translate(direction * (_movespeed * Time.deltaTime));
    }
}
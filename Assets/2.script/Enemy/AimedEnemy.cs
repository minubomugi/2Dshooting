using UnityEngine;

public class AimedEnemy : Enemy
{
    private GameObject player;

    // 09/03 수업 과제 3-2
    protected override void Move()
    {
        Vector2 direction = new Vector2(0, player.transform.position.y - transform.position.y).normalized;
        transform.Translate(direction * (_movespeed * Time.deltaTime));
    }
}
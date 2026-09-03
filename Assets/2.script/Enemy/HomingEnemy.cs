using UnityEngine;

public class HomigEnemy : Enemy
{
    // 09/03 수업 과제 3-3
    protected override void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = ((Vector2)player.transform.position
                             - (Vector2)transform.position).normalized;
        transform.Translate(direction * (_movespeed * Time.deltaTime));
    }
}
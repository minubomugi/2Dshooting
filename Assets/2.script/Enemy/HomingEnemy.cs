using UnityEngine;

public class HomigEnemy : Enemy
{
    // 09/03 수업 과제 3-3
    protected override void Move()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = ((Vector2)player.transform.position
                             - (Vector2)transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f);
        transform.Translate(direction.normalized * (_movespeed * Time.deltaTime), Space.World);
    }
}
using UnityEngine;

public class DownawadEnemy : Enemy
{
    // 09/03 수업 과제 3-1
    protected override void Move()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player == null)
        {
            Debug.LogWarning("Null값 보셈");
            return;
        }

        Vector2 direction = Vector2.down;
        transform.Translate(direction * (_movespeed * Time.deltaTime));
    }
}
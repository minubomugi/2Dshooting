using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 100;
    public float Movespeed;

    private void Update()
    {
        PlayerDirectionMove();
    }

    private void EnemyMove()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * (Movespeed * Time.deltaTime));
    }

    private void PlayerDirectionMove()
    {
        Vector2 direction = ((Vector2)GameObject.FindGameObjectWithTag("Player").transform.position
                             - (Vector2)transform.position).normalized;
        transform.Translate(direction * (Movespeed * Time.deltaTime));
    }

    private void PlayerChase()
    {
    }
}
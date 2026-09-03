using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health = 100;
    public float Movespeed;

    private void Update()
    {
        PlayerChase();
    }

    // 09/03 수업과제 3-1
    private void EnemyMove()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * (Movespeed * Time.deltaTime));
    }

    // 09/03 수업 과제 3-2
    private void PlayerDirectionMove()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = new Vector2(0, player.transform.position.y - transform.position.y).normalized;
        transform.Translate(direction * (Movespeed * Time.deltaTime), Space.World);
    }

    // 09/03 수업 과제 3-3
    private void PlayerChase()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = ((Vector2)player.transform.position
                             - (Vector2)transform.position).normalized;
        transform.Translate(direction * (Movespeed * Time.deltaTime), Space.World);
    }
}
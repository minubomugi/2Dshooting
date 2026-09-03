using System;
using UnityEngine;


public class BulletMove : MonoBehaviour
{
    public float MoveSpeed;
    public float Damage;

    private void Update()
    {
        Bullet();
    }

    private void Bullet()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * (MoveSpeed * Time.deltaTime));
    }

    //충돌 관련 이벤트 (Enter -> stay -> Exit)
    // 충돌이 시작되면 호추뢰는 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 시작");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("충돌 중");

        // 충돌 친구가 Enemy일 때만 -> tag이용
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //나죽고
            Destroy(this.gameObject);
            
            // Get component<타입>() -> 게임 오브젝트가 갖고 있는 컴포넌트를참조
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Health -= 40;
            if (enemy.Health <= 0)
            {
                //너 죽자
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("충돌 끝");
    }
}
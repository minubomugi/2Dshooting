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

    // Omtrigger 관련 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //나죽고
            Destroy(this.gameObject);

            // Get component<타입>() -> 게임 오브젝트가 갖고 있는 컴포넌트를참조
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            //발사체 크기에 따른 데미지 차이 부여
            enemy.TakeDamage(Damage);
        }
    }

    //충돌 관련 이벤트 (Enter -> stay -> Exit)
    // 충돌이 시작되면 호추뢰는 이벤트 함수
    //  private void OnCollisionEnter2D(Collision2D collision)
    //  {
    //     Debug.Log("충돌 시작");
    //  }

    //    private void OnCollisionStay2D(Collision2D collision)
    //    {
    //        Debug.Log("충돌 중");

    // 충돌 친구가 Enemy일 때만 -> tag이용
    //        if (collision.gameObject.CompareTag("Enemy"))
    //        {
    //나죽고
    //           Destroy(this.gameObject);

    // Get component<타입>() -> 게임 오브젝트가 갖고 있는 컴포넌트를참조
    //           Enemy enemy = collision.gameObject.GetComponent<Enemy>();

    //발사체 크기에 따른 데미지 차이 부여
    //             enemy.TakeDamage(Damage);
    //       }
    //  }


    //  private void OnCollisionExit2D(Collision2D collision)
    // {
    //    Debug.Log("충돌 끝");
    //}
}
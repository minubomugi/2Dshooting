using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class BulletMove : MonoBehaviour
{
    public float MoveSpeed;
    public float Damage;

    private AudioSource _audioSource;

    [SerializeField] BulletType _bulletType;
    public BulletType BulletType => _bulletType;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // 활성화 될 때마다 자동으로 호출되는 이벤트 함수
    private void PlaySound()
    {
        Debug.Log("총알 활성화");
        _audioSource.pitch = Random.Range(-0.5f, 3f);
        _audioSource.Play();
    }

    public void OnSpawn()
    {
        // 프리펩이 풀에 의해서 활성화 될 때마다
        // 초기화하는 코드들이 들어간다.
        PlaySound();
    }

    private void Update()
    {
        Bullet();
    }

    private void Bullet()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * (MoveSpeed * Time.deltaTime));
    }

    // Ontrigger 관련 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Get component<타입>() -> 게임 오브젝트가 갖고 있는 컴포넌트를참조
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            //발사체 크기에 따른 데미지 차이 부여
            enemy.TakeDamage(Damage);
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
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
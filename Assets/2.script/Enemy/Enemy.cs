using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _health = 100;
    [SerializeField] protected float _movespeed;

    [SerializeField] protected float _damage;

    // 아이템 확률
    [Header("아이템 스폰 확률")] [SerializeField] private float _dropPercent = 0.3f;

    //생성 프리팹
    [Header("스폰할 아이템 프리팹")] [SerializeField]
    private GameObject[] _itemPrefabs;

    // 애니메이터 연결
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Itemdrop()
    {
        if (Random.value < _dropPercent)
        {
            int index = Random.Range(0, _itemPrefabs.Length);
            Instantiate(_itemPrefabs[index], transform.position, Quaternion.identity);
        }
    }

    protected abstract void Move();

    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        _health -= damage;
        _animator.SetTrigger("Bullet Hit");
        if (_health <= 0)
        {
            Destroy(gameObject);
            Itemdrop();
        }
    }

    // 시습과제 09/04 1. 플레이어에게 체력, 적에게 대미지를 만들어서 충돌시 공격 처리
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                float damage = _movespeed * _damage;

                player.TakeDamage((int)damage);
            }

            //나죽고
            Destroy(this.gameObject);
        }
    }
}
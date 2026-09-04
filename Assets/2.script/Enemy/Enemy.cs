using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _health = 100;
    [SerializeField] protected float _movespeed;
    [SerializeField] protected float _damage;

    private void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
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

                player.TakeDamage(damage);
            }

            //나죽고
            Destroy(this.gameObject);
        }
    }
}
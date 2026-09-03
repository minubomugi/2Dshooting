using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _health = 100;
    [SerializeField] protected float _movespeed;

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
}
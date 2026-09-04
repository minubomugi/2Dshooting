using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어 체력 입력 받는 것
    [Header("플레이어 체력")] [SerializeField] private float _hp = 100f;

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        if (this._hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
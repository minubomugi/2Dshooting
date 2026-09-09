using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    [Header("필살기")] [SerializeField] private GameObject _specialAttackPrefab;
    [SerializeField] private Transform _specialAttackPoint;

    [Header("차징 이펙트")] [SerializeField] private GameObject _playerChargingEffect;

    [Header("쿨타임")] [SerializeField] private float _coolTime = 10f;

    private float _lastUseTime = -999f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            UseSpecialAttack();
        }
    }

    private void UseSpecialAttack()
    {
        if (Time.time - _lastUseTime < _coolTime)
        {
            return;
        }

        _lastUseTime = Time.time;

        // 차징 효과
        GameObject chargingEffect = Instantiate(_playerChargingEffect, transform.position, Quaternion.identity);

        Destroy(chargingEffect, 1f);

        // 플레이어 앞에 필살기 생성
        Instantiate(_specialAttackPrefab, _specialAttackPoint.position, Quaternion.identity);
    }
}
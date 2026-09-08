using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    [SerializeField] private GameObject _playerSkillEffect;
    [SerializeField] private GameObject _playerChargingEffect;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _coolTime = 10f;
    private float _lastUseTime = -999f;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            UseSpecialAttack();
        }
    }

    private void UseSpecialAttack()
    {
        // 쿨 타임 지정
        if (Time.time - _lastUseTime < _coolTime)
        {
            return;
        }

        // 연출 생성
        GameObject effect = Instantiate(_playerSkillEffect, transform.position, Quaternion.identity);
        Instantiate(_playerChargingEffect, transform.position, Quaternion.identity);

        // 연출 범위 가져오기
        Renderer effectRenderer = effect.GetComponentInChildren<Renderer>();
        if (effectRenderer == null)
            return;

        // 렌더러가 차지하고있는 영역 가져옴
        Bounds bounds = effectRenderer.bounds;

        // 연출 범위 만큼, 공격 판정
        Collider2D[] colliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0f, _enemyLayer);
        foreach (Collider2D hit in colliders)
        {
            Enemy enemy = hit.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}
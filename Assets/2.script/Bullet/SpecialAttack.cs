using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    [Header("필살기 이동 속도")] [SerializeField] private float _moveSpeed = 5f;

    [Header("폭발 크기")] [SerializeField] private float _explosionScale = 3f;

    [Header("적 레이어")] [SerializeField] private LayerMask _enemyLayer;

    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _shakeTimer = 0.7f;
    [SerializeField] private float _shakePower = 0.2f;

    private bool _isExploded = false;

    // 카메라 호출
    private CameraShake _cameraShake;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        if (_cameraShake == null)
        {
            Debug.LogWarning("CameraShake 못 찾음!");
        }
    }

    private void Update()
    {
        // 폭발하기 전까지만 이동
        if (!_isExploded)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.up * (_moveSpeed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponentInParent<Enemy>();

        if (enemy == null || _isExploded)
        {
            return;
        }

        // 한 번만 폭발
        _isExploded = true;

        Explosion();
    }

    private void Explosion()
    {
        Debug.Log("필살기 실행");
        // 필살기를 크게 만듦
        transform.localScale *= _explosionScale;

        // 커진 이미지의 범위 가져오기
        Bounds bounds = _spriteRenderer.bounds;

        // 커진 범위 안에 있는 적 전부 찾기
        Collider2D[] colliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0f, _enemyLayer);

        foreach (Collider2D hit in colliders)
        {
            Enemy enemy = hit.GetComponentInParent<Enemy>();

            if (enemy != null)
            {
                // 현재 체력만큼 데미지 → 체력 0
                enemy.TakeDamage(enemy.Health);
            }
        }

        if (_cameraShake != null)
        {
            Debug.Log("Shake 호출!");
            _cameraShake.Shake(_shakeTimer, _shakePower);
        }

        // 폭발 모습 잠깐 보여준 뒤 삭제
        Destroy(gameObject, 0.3f);
    }
}
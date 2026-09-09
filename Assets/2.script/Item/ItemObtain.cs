using System;
using UnityEngine;

public class ItemObtain : MonoBehaviour
{
    // 아이템 획득 쿨타임
    [Header("아이템 획득 쿨타임")] [SerializeField]
    private float _coolTimer = 1.0f;

    private float _dropTimer;

    //아이템 획득 연출
    private PlayerItemEffect _playerItemEffect;

    // 애니메이션
    private Animator _animator;

    // 오디오
    [SerializeField] private AudioSource _itemMoveAudioSource;

    // 아이템 이동 속도
    [Header("아이템 이동 속도")] [SerializeField] private float _itemSpeed = 5f;

    // 아이템 종류
    [SerializeField] private ItemType Type;
    [SerializeField] private float Value;

    // 캐싱
    private Player _player;
    private Transform _playerTransform;
    private assignmnet0902 _move;
    private PlayerFire[] _playerFires;

    // 생성과 동시에 시간 저장 및 캐싱
    private void Start()
    {
        _dropTimer = Time.time;
        _animator = GetComponentInChildren<Animator>();
        GameObject player = GameObject.FindWithTag("Player");
        _itemMoveAudioSource = GetComponent<AudioSource>();

        if (player == null)
        {
            Debug.LogWarning("Player 태그를 가진 오브젝트가 없습니다.");
            return;
        }

        _player = player.GetComponent<Player>();
        _playerTransform = player.transform;
        _move = player.GetComponent<assignmnet0902>();
        _playerFires = player.GetComponents<PlayerFire>();
        _playerItemEffect = player.GetComponent<PlayerItemEffect>();
    }


    private void Update()
    {
        ItemMove();
    }


    // 일정 시간이 지난 후 플레이어 방향으로 이동
    private void ItemMove()
    {
        if (_playerTransform == null)
            return;

        if (Time.time - _dropTimer > _coolTimer)
        {
            _animator.enabled = true;
            Vector2 direction = ((Vector2)_playerTransform.position - (Vector2)transform.position).normalized;
            transform.Translate(direction * (_itemSpeed * Time.deltaTime));
        }
    }


    // 플레이어에게 닿았을 때 아이템 효과 적용
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (_player == null)
        {
            Debug.LogWarning("Player 컴포넌트를 찾을 수 없습니다.");
            return;
        }

        switch (Type)
        {
            case ItemType.Heal:
            {
                _player.TakeDamage((int)(Value * -1));
                Debug.Log($"플레이어 체력: {_player.GetHealth()}");
                break;
            }

            case ItemType.MoveSpeedUp:
            {
                if (_move != null)
                {
                    _move.Speed = Mathf.Min(10f, _move.Speed + Value);
                }

                break;
            }

            case ItemType.FireRateUp:
            {
                foreach (PlayerFire playerFire in _playerFires)
                {
                    playerFire.CoolTime = Mathf.Max(0.1f, playerFire.CoolTime * 0.9f);
                }

                break;
            }
        }

        if (_playerItemEffect != null)
        {
            _playerItemEffect.PlayEffect(Type);
        }

        Destroy(gameObject);
    }
}
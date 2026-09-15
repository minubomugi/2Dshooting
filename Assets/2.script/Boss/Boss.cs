using UnityEngine;

public class Boss : MonoBehaviour
{
    // 기본 스탯 설정
    [SerializeField] private float _health;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] private float _damage;

    //애니메이션 및 오디오 소스 설정
    private Animator _animator;
    private AudioSource _audioSource;

    //생성 프리팹
    [Header("죽고 스폰할 아이템 프리팹")]
    [SerializeField] private ItemSpawnData[] _itemSpawnDatas;

    // 죽을 때 생성할 이펙트 프리펩
    [SerializeField] private GameObject _deathEffectPrefab;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
}
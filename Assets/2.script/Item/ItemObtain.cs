using UnityEngine;

public class ItemObtain : MonoBehaviour
{
    // 아이템 획득 쿨타임 적용
    [Header("아이템 획득 쿨타임")] [SerializeField]
    private const float _coolTimer = 1.0f;

    private float _dropTimer;
    [Header("아이템 이동 속도")] [SerializeField] private const float _itemSpeed = 5f;

    // 아이템 종류
    [SerializeField] private ItemType Type;
    [SerializeField] private float Value;

    // 생성과 동시에 시간 저장
    private void Start()
    {
        _dropTimer = Time.time;
    }

    // 일정 시간 지난 후 이동
    private void Update()
    {
        ItemMove();
    }

    private void ItemMove()
    {
        if (Time.time - _dropTimer > _coolTimer)
        {
            Player player = GameObject.FindWithTag("Player").GetComponent<Player>();
            Vector2 direction = ((Vector2)player.transform.position
                                 - (Vector2)transform.position).normalized;
            transform.Translate(direction * (_itemSpeed * Time.deltaTime));
        }
    }

    // 플레이어에게 닿을 시 아이템 삭제
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Player player = other.GetComponent<Player>();
        if (player == null)
        {
            Debug.LogWarning("플레이어 태그 오브젝트에 플레이어 컴포넌트가 없습니다.");
            return;
        }

        switch (Type)
        {
            case ItemType.Heal:
            {
                player.TakeDamage((int)(Value * -1));
                break;
            }

            case ItemType.MoveSpeedUp:
            {
                assignmnet0902 move = player.GetComponent<assignmnet0902>();

                if (move != null)
                {
                    move._speed = Mathf.Min(10f, move._speed + Value);
                }

                break;
            }

            case ItemType.FireRateUp:
            {
                PlayerFire[] playerFires = player.GetComponents<PlayerFire>();

                foreach (PlayerFire playerFire in playerFires)
                {
                    playerFire.CoolTime =
                        Mathf.Max(0.1f, playerFire.CoolTime - Value);
                }

                break;
            }
        }

        Destroy(this.gameObject);
    }
}
using UnityEngine;

public class Player : MonoBehaviour
{
    // 캡슐화
    //- 데이터 은닉
    // - 메서드를 통한 상태 변경
    // 플레이어 체력 입력 받는 것
    [Header("플레이어 체력")] [SerializeField] private int _hp = 100;
    [SerializeField] private GameObject _deathEffectPrefab;

    // getter/setter : 특정 데이터를 get/set 해주는 메서드
    public int GetHealth()
    {
        return _hp;
    }

    public int Health
    {
//        set
//        {
//            if (value < 0)
//           {
//                return;
//            }
//            _hp = value;
//        }
        get { return _hp; }
        set { _hp = value; }
    }

    // 잘 설계된 클래스는 
    // - 필드(인스턴스 변수)와
    // - 필드에 잘못된 값이 할당되지 않게 막고(무결성을 유지하고), 정상적으로 동작하는 메소드
    // 무결성 검사를 해야한다.
    // 무결성: 잘못된 데이터가 들어가지 않게 하는 것
    // 규칙: 최대 체력보다 체력은 적어야 한다.

    public void TakeDamage(int damage) // 기술지향 메소드라 지양됨
    {
        Health -= damage;
        if (Health <= 0)
        {
            Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성


    //생성위치
    public Transform LeftFirePointTransform;
    public Transform RightFirePointTransform;
    public Transform LeftSubFirePointTransform;
    public Transform RightSubFirePointTransform;

    // 쿨타이머
    public float CoolTime = 0.5f;
    public float CoolTimer = 0;

    //- 오토 모드
    public bool _autoFireMode = false;

    public void SetAuto(bool auto)
    {
        _autoFireMode = auto;
    }

    private void Start()
    {
        CoolTimer = CoolTime;
    }

    private void Update()
    {
        // 오토 공격 모드 토글
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _autoFireMode = !_autoFireMode; // 토글
        }


        // 0.쿨타이머 감소
        CoolTimer -= Time.deltaTime;

        // 1. 쿨타이머가 0초이하이고 같이 스페이스바 누르거나 오토 모드리면
        if (CoolTimer <= 0 && (Input.GetKeyDown(KeyCode.Space) || _autoFireMode))
        {
            // 2. 발사
            Fire();

            // 3. 쿠라이머 초기화
            CoolTimer = CoolTime;
        }
    }

    //1. 스페이스바를 누르면
    private void Fire()
    {
        BulletMove leftBullet = BulletPool.Instance.GetBullet(BulletType.Main);
        leftBullet.transform.position = LeftFirePointTransform.position;

        BulletMove rightBullet = BulletPool.Instance.GetBullet(BulletType.Main);
        rightBullet.transform.position = RightFirePointTransform.position;

        BulletMove LeftSubBullet = BulletPool.Instance.GetBullet(BulletType.Sub);
        LeftSubBullet.transform.position = LeftSubFirePointTransform.position;

        BulletMove RightSubBullet = BulletPool.Instance.GetBullet(BulletType.Sub);
        RightSubBullet.transform.position = RightSubFirePointTransform.position;

        Debug.Log($"Main : {leftBullet.GetInstanceID()} / {rightBullet.GetInstanceID()}");
        Debug.Log($"Sub : {LeftSubBullet.GetInstanceID()} / {RightSubBullet.GetInstanceID()}");
    }
}
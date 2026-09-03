using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // 총알 프리팹
    public GameObject BulletPrefab;

    //생성위치
    public Transform LeftFirePointTransform;
    public Transform RightFirePointTransform;

    // 쿨타이머
    public float CoolTime = 0.5f;
    public float CoolTimer = 0;

    //- 오토 모드
    public bool AutoFireMode = false;

    private void Start()
    {
        CoolTimer = CoolTime;
    }

    private void Update()
    {
        // 오토 공격 모드 토글
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AutoFireMode = !AutoFireMode; // 토글
        }


        // 0.쿨타이머 감소
        CoolTimer -= Time.deltaTime;

        // 1. 쿨타이머가 0초이하이고 같이 스페이스바 누르거나 오토 모드리면
        if (CoolTimer <= 0 && (Input.GetKeyDown(KeyCode.Space) || AutoFireMode))
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
        //2. 총알 프리팹을 생성한다.
        //Instantiate는 프리팹으로부터 복사해서 게임 오브젝트를 만들고 씬에 넣어주는 기능

        //5. 실습과제 발사하는 곳 2개 만들기
        GameObject leftBullet = Instantiate(BulletPrefab);
        leftBullet.transform.position = LeftFirePointTransform.position;
        GameObject rightBullet = Instantiate(BulletPrefab);
        rightBullet.transform.position = RightFirePointTransform.position;
    }
}
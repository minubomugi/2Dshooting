using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // 총알 프리팹
    public GameObject BulletPrefab;
    //생성위치
    public Transform firePoint;
    private void Update()
    {
        //1. 스페이스바를 누르면
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //2. 총알 프리팹을 생성한다.
            //Instantiate는 프리팹으로부터 복사해서 게임 오브젝트를 만들고 씬에 넣어주는 기능
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.transform.position = firePoint.position;
        }
    }
}

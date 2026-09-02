using UnityEngine;

public class assignmnet0902 : MonoBehaviour
{
    public float Speed;
    public float limit;

    private void Update() //객체의 이벤트래
    {
        Move();
        SpeedChange(); // 콘텐츠 중심 명명법으로 짓는게 편해
        //InputSpeedKey() -> 옛날에 명령받아서 진행하는 입력받아 하는 기능중심 명명법
    }

    private void SpeedChange()
    {
        //실습 과제 3 e버튼 누르면 스피드 업, q버튼누르면 스피드 1다운
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed++;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Speed--;
        }
    }

    private void Move()
    {
        //똑같이 이동할 수 있는 거 처리
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 nomalizedDirection = new Vector2(h, v).normalized;
        Vector2 newPosition = transform.position + (Vector3)nomalizedDirection * (Speed * Time.deltaTime);
       
        //실습 과제 1 특정 영역 안에서만 캐릭터가 이동할 수 있게        
        if (transform.position.y < -limit)
        {
            v = -limit;
        }
        if (transform.position.x < -limit)
        {
            h = -limit;
        }
        if (transform.position.y > limit)
        {
            v = limit;
        }
        if (transform.position.x > limit)
        {
            h = limit;
        }
        
        //실습 과제 2 좌우 이동에 있어 쭈욱 이동시 반대쪽에서 나오기
        if (transform.position.y < -limit)
        {
            transform.position = new Vector3(transform.position.x, limit, 0);
        }
        if (transform.position.x < -limit)
        {
            transform.position = new Vector3(limit, transform.position.y, 0);
        }
        if (transform.position.y > limit)
        {
            transform.position = new Vector3(transform.position.x, -limit, 0);
        }
        if (transform.position.x > limit)
        {
            transform.position = new Vector3(-limit, transform.position.y, 0);
                    
            //이동
            transform.Translate(nomalizedDirection * (Speed * Time.deltaTime));
        }
    }
}

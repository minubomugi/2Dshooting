using UnityEngine;

public class assignmnet0902 : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        //똑같이 이동할 수 있는 거 처리
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        int limit = 3;
        Vector2 direction = new Vector2(h, v);
        Vector2 nomalizedSpeed = new Vector2(Speed, Speed).normalized;
       
        //실습 과제 1 특정 영역 안에서만 캐릭터가 이동할 수 있게        
        if (transform.position.y < -limit)
        {
            v = Mathf.Max(Input.GetAxis("Vertical"),0f);
        }
        if (transform.position.x < -limit)
        {
            h = Mathf.Max(Input.GetAxis("Horizontal"),0f);
        }
        if (transform.position.y > limit)
        {
            v = Mathf.Min(Input.GetAxis("Vertical"),0f);
        }
        if (transform.position.x > limit)
        {
            h = Mathf.Min(Input.GetAxis("Horizontal"),0f);
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
        }
        
        //실습 과제 3 e버튼 누르면 스피드 업, q버튼누르면 스피드 1다운
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed++;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Speed--;
        }
        
        //이동
        transform.Translate(direction*nomalizedSpeed * Time.deltaTime);
    }
}

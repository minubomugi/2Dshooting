using UnityEngine;

public class Playermove : MonoBehaviour
{
    // 목적: 키보드 입력에 따라서플레이어 이동 처리를 하고 싶다.

    // 지속적인 사용을 위해서 스사트 함수는 삭제
    // 구현 순서는 다음과 같다.
    // 1. 키보드 입력을 받는다.
    // 2. 키보드 입력에 따라 방향을 구한다.
    // 3. 방향과 속도에 따라 이동한다.

    
    // 필요 변수
    public float Speed;
    
    // 업데이트는 매 프레임마다 실행된다.
    // 초당 프레임 실행 횟수는 별다른 설정 없는 경우 가능한 많이 실행
    private void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 키보드 왼/오른쪽 입력 상태에 따라 -1f~0~1f
        float v = Input.GetAxis("Vertical"); //키보드 위/아래 입력 상태에 따라 -1f~0~1f
        
        Debug.Log($"h:{h} v:{v}");

        Vector2 direction = new Vector2(h,v); //왼쪽 방향
        
        //새로운 위치는 = 현재 위치 + (방향 * 속력 * 시간)
        // transform.position += (Vector3)direction * Speed * Time.deltaTime;
        
// 1. 키보드 입력을 받는다.
        // 유니티는 다른 기능도 해준다 오른쪽 코드를 ->if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Debug.Log("님 왼쪽 누르고 이동중");
        // 2. 키보드 입력에 따라 방향을 구한다.
        // 게임에는 벡터라는 탕비이 있다. 벡터는 크기와 방향을 의미한다.
        //   Vector2 direction = new Vector2(-1, 0); // 왼쪽 방향
        //똑같은 방식 -> Vector2 direction = Vector2.left;

        // 3. 방향과 속력에 따라 이동한다. 
        // 매개변수 속도 = 방향 * 속력               //매직 넘버란; 보는 사람에 따라 의미가 달라지는 것
        // 헷갈리는 숫자, 코드에는 숫자 있으면 안됨
        // 그래서 변수 넣어야 해
        //   transform.Translate(direction * Speed* Time.deltaTime);
        // deltaTime: 이전 프레임으로부터 지금 프레임 까지 시간이 얼마나 지났는지 ms(천분의 1초)로 반환
    }
}


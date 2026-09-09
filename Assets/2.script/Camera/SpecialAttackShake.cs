using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPosition;

    private float _shakeTimer;
    private float _shakePower;

    private bool _isShaking;

    private void Update()
    {
        if (!_isShaking)
        {
            return;
        }

        if (_shakeTimer > 0f)
        {
            Vector2 randomPosition = Random.insideUnitCircle * _shakePower;

            transform.localPosition = _originalPosition + new Vector3(randomPosition.x, randomPosition.y, 0f);

            _shakeTimer -= Time.deltaTime;
        }
        else
        {
            // 진동이 끝난 순간 딱 한 번 원위치
            transform.localPosition = _originalPosition;

            _isShaking = false;
        }
    }

    public void Shake(float duration, float power)
    {
        Debug.Log("CameraShake의 Shake 함수 들어옴!");
        // 진동을 시작하는 순간의 카메라 위치 저장
        _originalPosition = transform.localPosition;

        _shakeTimer = duration;
        _shakePower = power;

        _isShaking = true;
    }
}
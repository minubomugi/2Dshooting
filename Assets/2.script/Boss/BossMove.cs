using UnityEngine;

public class BossMove : Boss
{
    [SerializeField] private float _stopY;
    [SerializeField] private float _Limit;

    private bool _isEntered = true;

    private void Update()
    {
        if (!_isEntered)
        {
            return;
        }
    }

    private void VerticalMove()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
        if (transform.position.y < _stopY)
        {
            transform.position = new Vector2(transform.position.x, _stopY);
            _isEntered = false;
        }
    }
}
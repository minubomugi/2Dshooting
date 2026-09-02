using UnityEngine;


public class BulletMove : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        Bullet();
    }

    private void Bullet()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * (Speed * Time.deltaTime));
    }
}
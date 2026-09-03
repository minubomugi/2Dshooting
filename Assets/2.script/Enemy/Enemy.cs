using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;

    private void Update()   
    {
        Enemy();
    }

    private void Enemy()
    {
        Vector2 direction = Vector2.up;
        transform.Translate(direction * (speed * Time.deltaTime));
    }
}
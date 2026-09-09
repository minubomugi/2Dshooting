using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private float _offSetY = 0f;
    private Material _material;
    [SerializeField] private float _scrollSpeed = 0.1f;


    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        _offSetY += Time.deltaTime * _scrollSpeed;
        _material.mainTextureOffset = new Vector2(0, _offSetY);
    }
}
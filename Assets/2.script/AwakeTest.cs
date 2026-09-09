using UnityEngine;

public class AwakeTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        Debug.Log($"[Awake] {gameObject.name}]");
    }

    private void Start()
    {
        Debug.Log($"[Start] {gameObject.name}");
    }

    private void Update()
    {
        Debug.Log($"[Update] {gameObject.name}");
    }
}
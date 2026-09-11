using UnityEngine;

// 데이터 클래스: 순수하게 (값)을 보관하고 전달하는 목적으로 만든 특별한 클래스
[System.Serializable]
public class ItemSpawnData
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private int _weight;
    [SerializeField] private int _speed;

    //프로퍼티 설정
    public GameObject ItemPrefab => _itemPrefab;
    public ItemType ItemType => _itemType;
    public int Weight => _weight;
    public int Speed => _speed;
}
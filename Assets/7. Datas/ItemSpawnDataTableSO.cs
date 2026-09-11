using UnityEngine;

[CreateAssetMenu(fileName = "ItemSpawnDataTable", menuName = "Scriptable Objects/ItemSpawnDataTable")]
public class ItemSpawnDataTableSO : ScriptableObject
{
    [SerializeField] private ItemSpawnData[] _itemDatas;
    public ItemSpawnData[] ItemDatas => _itemDatas;
}
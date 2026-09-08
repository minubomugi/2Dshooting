using UnityEngine;

public class PlayerItemEffect : MonoBehaviour
{
    //플레이어에게 아이템 획득 연출]
    [SerializeField] private GameObject[] _itemEffectprefab;

    public void PlayEffect(ItemType type)
    {
        int index = (int)type;
        Instantiate(_itemEffectprefab[index], transform.position, Quaternion.identity);
    }
}
using Unity.VisualScripting;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private static BulletPool _instance = null;
    public static BulletPool Instance => _instance;

    // 오브젝트 풀링이란: 오브젝트의 Pool(웅덩이: 창고)를 만들어두고,
    // 그 창고 안에 게임 오브젝트를 미리 필요한 만큼 만들어두고,
    // 필요할 때마다 꺼내서 사용하고 필요가 없으면 반환하는 식으로
    // 메모리 할당(객체의 생성)과 해제(파괴)를 최소화해서 성능 향상
    [Header("총알 프리팹들")]
    [SerializeField] private BulletMove[] _bulletPrefabs;

    [Header("풀 사이즈")]
    [SerializeField] private int _poolSize;

    // 생성한 총알을 담어둘 풀
    private BulletMove[,] _bulletPool;

    private void Awake()
    {
        // 싱글톤화
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        // 창고를 창고 크기만큼 만든다.
        _bulletPool = new BulletMove[_bulletPrefabs.Length, _poolSize];

        // 총알 프리팹 종류와 창고 ㅋ기 만큼 총알을 미리 만들어서 집어 넣는다.
        //창고 크기 만큼 총알을 미리 만들어서 집어 넣는다.
        for (int i = 0; i < _bulletPool.Length; i++)
        {
            BulletMove bulletPrefab = _bulletPrefabs[i];
            for (int j = 0; j < _poolSize; j++)
            {
                BulletMove bullet = Instantiate(bulletPrefab, gameObject.transform);
                bullet.gameObject.SetActive(false);
                _bulletPool[i, j] = bullet;
            }
        }
    }

    public BulletMove GetBullet(BulletType bulletType)
    {
        for (int i = 0; i < _bulletPool.GetLength(0); i++)
        {
            if (_bulletPool[i, 0].BulletType != bulletType)
            {
                continue;
            }

            for (int j = 0; j < _bulletPool.GetLength(1); j++)
            {
                BulletMove bullet = _bulletPool[i, j];

                if (bullet.gameObject.activeSelf == false)
                {
                    bullet.gameObject.SetActive(true);
                    bullet.OnSpawn();
                    return bullet;
                }
            }
            // 비활성화 되어있는 (즉, 누가 빌려가지 않은 총알 반환)
        }

        return null;
    }
}
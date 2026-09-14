using System;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    // 관리: 특정 데이터에 대한 무결성과 생성, 조회, 수정, 삭제 등과 관련된 게임 로직
    // 현재의 경우, 게임 업그레이드에 사용하는 업그레이드 매니저이다.
    private static UpgradeManager _instance = null;
    public static UpgradeManager Instance => _instance;

    [SerializeField] private Upgrade[] _upgrades;
    public Upgrade[] Upgrades => _upgrades;

    [SerializeField] private UI_Upgrade[] _uiUpgrades;

    // 싱글톤 적용
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    public void Start()
    {
        RefreshUI();
        LevelUp(1);
    }

    public void LevelUp(int index)
    {
        Upgrade upgrade = _upgrades[index];

        if (ScoreManager.Instance._score < upgrade.Cost)
        {
            return;
        }

        ScoreManager.Instance.SpendScore(upgrade.Cost);

        _upgrades[index].LevelUp();
        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (UI_Upgrade uiUpgrade in _uiUpgrades)
        {
            uiUpgrade.Refresh();
        }
    }
}
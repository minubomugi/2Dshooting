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

    private const string UpgradeSaveDataKey = "UpgradeSaveData";

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
        Load();
        RefreshUI();
        LevelUp(1);
    }

    public void LevelUp(int index)
    {
        //Todo: 묻지말고 시켜라!
        //골드 매니저에게 돈이있는지 물어보고 돈이 있다면 차감후 업그레이드 호출

        Upgrade upgrade = _upgrades[index];

        if (ScoreManager.Instance._score < upgrade.Cost)
        {
            return;
        }

        ScoreManager.Instance.SpendScore(upgrade.Cost);

        _upgrades[index].LevelUp();

        Save();

        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (UI_Upgrade uiUpgrade in _uiUpgrades)
        {
            uiUpgrade.Refresh();
        }
    }

    private void Save()
    {
        //데이터 저장은 유의미한 정보만 저장을 한다 ex) 레벨(계산 가능)
        // 그래서 여기선 레벨만 저장함

        UpgradeSaveData saveData = new UpgradeSaveData(_upgrades.Length);
        for (int i = 0; i < _upgrades.Length; i++)
        {
            saveData._name[i] = _upgrades[i].Name;
            saveData._level[i] = _upgrades[i].Level;
        }
        // 게임 데이터의 경우 확장자가 게임별로 다 다르다.
        // json 포멧으로 문자열 전환
        // 키와 밸루 형태로 저장한 형태

        string text = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(UpgradeSaveDataKey, text);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(UpgradeSaveDataKey)) return;

        string json = PlayerPrefs.GetString(UpgradeSaveDataKey, string.Empty);
        UpgradeSaveData saveData = JsonUtility.FromJson<UpgradeSaveData>(json);

        for (int i = 0; i < _upgrades.Length; i++)
        {
            Debug.Log($"{_upgrades[i].Name} 로드 완료!");
            _upgrades[i].SetLevel(saveData._level[i]);
        }
    }
}
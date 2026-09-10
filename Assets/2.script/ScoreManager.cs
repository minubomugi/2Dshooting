using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 싱글톤 패턴
    // 1. 전역적으로 누구를 뜻한지 안다.
    // 2. 그 누구가 한명인 것을 안다. -> 인스턴스(생성된 객체)가 하나임을 보장한다.
    // statinc(정적)
    private static ScoreManager _instance;

    public static ScoreManager Instance => _instance;

    // 관리: 특정 데이터에 대한 무결성과 생성, 읽기, 수정, 삭제 등과 관련된 로직
    private int _bestScore;
    private int _currentScore = 0;

    // 저장키 생성
    private const string _saveKey = "BestScore";

    // UI 책임 추가(텍스트에서 프로 참조)
    [SerializeField] private TextMeshProUGUI _bestScoreTextUI;
    [SerializeField] private TextMeshProUGUI _currentScoreTextUI;

    private void Awake()
    {
        // 늦게 생성된 매니저는 중복이 허용되지 않으므로 삭제
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    // 프로퍼티 작성
    public void AddScore(int score)
    {
        if (score <= 0) return;

        _currentScore += score;
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;

            // 저장: PlaterPrefs.set 시리즈를 이용해서 Int/float/string을 저장 가능하다.
            // 내 컴퓨터 어딘가에 저장이 된다.
            PlayerPrefs.SetInt(_saveKey, _bestScore);

            // 저장 정보 날라갈 수도 있으니 이렇게 저장
            PlayerPrefs.Save();
        }

        Refresh();
    }

    private void Start()
    {
        // 입력: Input
        // 저장 및 불러오기: PlayerPrefs
        if (PlayerPrefs.HasKey(_saveKey)) //GetInt(name, "0")으로 해서 값저장 역시 가능
        {
            _bestScore = PlayerPrefs.GetInt(_saveKey);
        }

        Refresh();
    }

    private void Refresh()
    {
        // 추가 점수 저장
        _bestScoreTextUI.text = $"Best Score: {_bestScore}";
        _currentScoreTextUI.text = $"Current Score: {_currentScore}";
    }
}
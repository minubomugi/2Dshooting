using System;
using UnityEngine;

[System.Serializable]
public class Upgrade
{
    // 기획자가 채우는 속성
    [SerializeField] private string _name;
    public string Name => _name;
    [SerializeField] private float _defaltValue;
    [SerializeField] private float _increaseValue;
    [SerializeField] private float _defaltCost;
    [SerializeField] private float _increaseCost;

    // 실행 중에 동적으로 바꿔 속성
    private int _level;
    public int Level => _level;
    private float _currentValue;
    public float CurrentValue => _currentValue;
    private float _nextValue;
    public float NextValue => _nextValue;
    private int _cost;
    public int Cost => _cost;

    public void SetLevel(int level)
    {
        _level = level;
        Calculate();
    }

    public Upgrade(string name, float defaltValue, float increaseValue, float defaltCost, int level)
    {
        _name = name;
        _defaltValue = defaltValue;
        _increaseValue = increaseValue;
        _defaltCost = defaltCost;
        _level = level;

        Calculate();
    }

    public void LevelUp()
    {
        _level++;
        Calculate();
    }

    public void Calculate()
    {
        // todo 공식에 따른 변화
        // value = 기본 벨류 + 레벨 * 증가량
        // Cost = 기본 점수 * 증가량 점수 ^ 레벨
        _currentValue = _defaltValue + _level * _increaseValue;
        _nextValue = _defaltValue + (_level + 1) * _increaseValue;
        _cost = (int)(_defaltValue + Mathf.Pow(_increaseCost, _level));
    }
}
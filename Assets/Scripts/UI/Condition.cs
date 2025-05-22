using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float StartValue;
    public float passiveValue;
    public Image uiBar;

    private void Start()
    {
        curValue = StartValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    public void Add(float value)
    {
        curValue = Mathf.Min(curValue + value, maxValue); //현재 값이 최대값을 넘지않도록 설정
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0.0f);//음수가 되지않도록 설정
    }

    public float GetPercentage()
    {
        return curValue / maxValue; //현재값의 퍼센트 구하기
    }
}

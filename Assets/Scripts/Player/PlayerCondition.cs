using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCondition : MonoBehaviour,IDamagable
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action onTakeDamage;

    private void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if(health.curValue < 0f)
        {
            Die();
        }
    }

    public void Heal(float value)
    {
        health.Add(value);
    }
    public void Eat(float value)
    {
        stamina.Add(value);
    }
    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicalDamage(int damageValue)
    {
        health.Subtract(damageValue);
        onTakeDamage?.Invoke();
    }
}

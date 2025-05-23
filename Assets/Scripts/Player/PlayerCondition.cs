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

    private bool isInvincible = false;

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

    public void SetInvincible(bool value)
    {
        isInvincible = value;
    }

    public void TakePhysicalDamage(int damageValue)
    {
        if (isInvincible)
        {
            return;
        }

        health.Subtract(damageValue);
        onTakeDamage?.Invoke();
    }

    public bool UseStamina(float value)
    {
        if (stamina.curValue - value < 0f)
        {
            return false;
        }

        stamina.Subtract(value);
        return true;
    }


}

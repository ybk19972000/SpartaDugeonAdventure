using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public Action addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();

        addItem += () => ApplyItemEffects(itemData);
    }
    public void ApplyItemEffects(ItemData itemData)
    {
        foreach (var consumable in itemData.consumables)
        {
            switch (consumable.type)
            {
                case ConsumableType.Health:
                    condition.Heal(consumable.value);
                    break;
                case ConsumableType.Stamina:
                    condition.Eat(consumable.value);
                    break;
                case ConsumableType.SpeedBoost:
                    StartCoroutine(ApplySpeedBoost(consumable.value, 5f));
                    break;
                case ConsumableType.JumpBoost:
                    StartCoroutine(ApplyJumpBoost(consumable.value, 5f));
                    break;
                case ConsumableType.Invincibility:
                    StartCoroutine(ApplyInvincibility(consumable.value));
                    FindObjectOfType<InvincibleIndicator>()?.InvincibleFlash(consumable.value);
                    break;
            }
        }
    }
    private IEnumerator ApplySpeedBoost(float value, float duration)
    {
        controller.speed += value;
        yield return new WaitForSeconds(duration);
        controller.speed -= value;
    }

    private IEnumerator ApplyJumpBoost(float value, float duration)
    {
        controller.jumpPower += value;
        yield return new WaitForSeconds(duration);
        controller.jumpPower -= value;
    }

    private IEnumerator ApplyInvincibility(float duration)
    {
        condition.SetInvincible(true);
        yield return new WaitForSeconds(duration);
        condition.SetInvincible(false);
    }
}

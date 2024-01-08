using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStamina : MonoBehaviour
{
    public SpriteRenderer staminaSpriteRenderer;
    public Sprite fullStaminaSprite;
    public Sprite halfStaminaSprite;
    public Sprite emptyStaminaSprite;

    public void UpdateStaminaVisuals(int currentStamina)
    {
        if (staminaSpriteRenderer != null)
        {
            if (currentStamina == 2)
            {
                staminaSpriteRenderer.sprite = fullStaminaSprite;
            }
            else if (currentStamina == 1)
            {
                staminaSpriteRenderer.sprite = halfStaminaSprite;
            }
            else if ( currentStamina == 0)
            {
                staminaSpriteRenderer.sprite = emptyStaminaSprite;
            }
        }
    }
}


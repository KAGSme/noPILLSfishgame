using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter_Health : MonoBehaviour
{
    private float healthPoints = 100;
    public Image healthBar;

    void Awake()
    {
        healthPoints = 100;
    }

    void Update()
    {
        if (healthPoints > 100) healthPoints = 100;
        healthBar.fillAmount = healthPoints / 100;
    }

    public void HealthDecrease(int damage)
    {
        if (healthPoints > 0) { healthPoints -= damage; }
    }

    public void HealthIncrease(int increase)
    {
        if (healthPoints < 100) { healthPoints += increase; }
    }

}

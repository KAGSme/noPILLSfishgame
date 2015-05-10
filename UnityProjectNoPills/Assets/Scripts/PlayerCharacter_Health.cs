using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter_Health : MonoBehaviour
{
    private float healthPoints = 100;
    public int healthPickUp = 33;
    public Image healthBar;
    private bool isInvisible = false;

    public bool IsInvisible
    {
        get { return isInvisible; }
        set { isInvisible = value; }
    }

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

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == "Health Pick Up")
        {
            Destroy(coll.gameObject);
            HealthIncrease(healthPickUp);
        }
    }
}

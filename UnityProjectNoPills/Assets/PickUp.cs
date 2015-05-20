using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public int healthGain = 34;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerCharacter_Health>().HealthIncrease(healthGain);
            Destroy(gameObject);
        }
    }
}

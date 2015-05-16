using UnityEngine;
using System.Collections;

public class DeadlyGas : MonoBehaviour {

    public int gasDamage = 10;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerCharacter_Health>().HealthDecrease(gasDamage);
        }
    }
}

using UnityEngine;
using System.Collections;

public class PillStandard : MonoBehaviour {

    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerCharacter_Health>().HealthDecrease(damage);
            DestroyObject(gameObject);
        }
    }
}

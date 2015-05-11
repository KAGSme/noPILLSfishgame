using UnityEngine;
using System.Collections;

public class PillDrunk : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerCharacter_Health>().DrunkIsOn = true;
            DestroyObject(gameObject);
        }
    }
}

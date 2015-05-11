using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class PillVision : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerCharacter_Health>().EffectIsOn = true;
            var vortex = Camera.main.GetComponent<Vortex>();
            var mb = Camera.main.GetComponent<MotionBlur>();
            vortex.enabled = true;
            mb.enabled = true;
            DestroyObject(gameObject);
        }
    }
}


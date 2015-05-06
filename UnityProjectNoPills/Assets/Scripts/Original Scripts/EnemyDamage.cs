using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	public float damageDealt = 50.0f;
	public GameObject parent;
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player"){
			Debug.Log("Enemy HIT!");
			GameObject player = GameObject.FindWithTag("Player");
			DamageScript script = (DamageScript)player.GetComponent(typeof(DamageScript));
			script.Damage(damageDealt);
			Destroy(parent);
			Debug.Log("Enemy GONE!");
		}
	}
}

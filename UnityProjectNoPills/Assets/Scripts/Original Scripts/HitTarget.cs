using UnityEngine;
using System.Collections;

public class HitTarget : MonoBehaviour {

	public float damage = 30;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){

			GameObject player = GameObject.FindWithTag("Player");
			DamageScript script = (DamageScript)player.GetComponent(typeof(DamageScript));
			script.Damage(damage);

			Debug.Log("hit");
			other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,-200,0));
			Destroy(this.gameObject);
		}
		if(other.gameObject.tag == "Destroyer"){
			Destroy(this.gameObject);
		}
	}

}

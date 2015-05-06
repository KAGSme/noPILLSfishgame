using UnityEngine;
using System.Collections;

public class MutatedEnemy : MonoBehaviour {

	public Transform targetPoint;
	private bool tranquil;
	public float enemySpeed; 

	void Start(){
		tranquil = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!tranquil){
			Debug.Log ("enemy pursueing");
			Follow();
		}
	}

	void OnTriggerEnter(Collider target){
		if(target.gameObject.tag == "Player"){
			Debug.Log("Player entered");
			targetPoint = target.gameObject.transform;
			tranquil = false;
		}
	}

	void Follow(){
		transform.LookAt(targetPoint.position);
		gameObject.GetComponent<ConstantForce>().relativeForce = new Vector3(0, 0, enemySpeed);
	}
}
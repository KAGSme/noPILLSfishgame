using UnityEngine;
using System.Collections;

public class DeadFishScript : MonoBehaviour {

	public float FloatStrenght;
	public float RandomRotationStrenght;

	
	void Update () {


		transform.GetComponent<Rigidbody>().AddForce(Vector3.up *FloatStrenght);
		transform.Rotate(0, 0, RandomRotationStrenght);
	
}
}

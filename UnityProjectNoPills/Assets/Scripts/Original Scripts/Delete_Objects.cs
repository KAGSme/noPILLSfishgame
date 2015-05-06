using UnityEngine;
using System.Collections;

public class Delete_Objects : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter (Collision col)
	{

		if (col.gameObject.tag == "Dead fish") {
			//Debug.Log("Test");
			Destroy (col.gameObject);
			}

		if (col.gameObject.tag == "Enemy") {
			Destroy (col.gameObject);
			}
	}

	// Update is called once per frame
	void Update () {
	
	}
}

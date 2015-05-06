using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public string level;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Player"){
			Application.LoadLevel(level);
		}
	}

}

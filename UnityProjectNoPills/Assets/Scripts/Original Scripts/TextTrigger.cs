using UnityEngine;
using System.Collections;

public class TextTrigger : MonoBehaviour {

	public string triggerName;


	void OnTriggerEnter(Collider other){
		GameObject trigger = GameObject.Find(triggerName);
		CharacterTextBubbles script = (CharacterTextBubbles)trigger.GetComponent(typeof(CharacterTextBubbles));
		if(other.gameObject.tag == "Player"){
			script.DrawBubble = true;
		}
	}

}

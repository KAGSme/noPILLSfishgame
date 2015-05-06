using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

    public float characterSpeed;
	public GameObject characterObject;
	public float backgroundSpeed;
	public float textureOffSetX;
	
	// Update is called once per frame
	void Update () {
		Vector3 xPos = transform.position;
		xPos.x = characterObject.transform.position.x;
		transform.position = xPos;

		textureOffSetX = GetComponent<Renderer>().material.mainTextureOffset.x;

		if (textureOffSetX > 1.0f || textureOffSetX < -1.0f){
			textureOffSetX -= 1.0f;
			GetComponent<Renderer>().material.mainTextureOffset -= new Vector2 (textureOffSetX,0);
		}

		characterSpeed = characterObject.GetComponent<Rigidbody>().velocity.x;

		if (characterSpeed >= 0.1f){
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(backgroundSpeed * Time.time, 0);
		}
		if (characterSpeed <= -0.1f){
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-backgroundSpeed * Time.time, 0);
		}
		if (characterSpeed > -0.1f && characterSpeed < 0.1f){
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(textureOffSetX,0);
		}
	}
}

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

		characterSpeed = characterObject.GetComponent<Rigidbody2D>().velocity.x;
        backgroundSpeed += (-characterSpeed / (characterObject.GetComponent<PlayerCharacter_Movement>().maxSpeed*2)) * Time.deltaTime;

        if (textureOffSetX >= 1 || textureOffSetX <= -1)
        {
            textureOffSetX = 0;
        }
        if (characterSpeed < 0.1 && characterSpeed > -0.1)
        {
            backgroundSpeed = 0;
        }
        if (characterSpeed > 0.1 || characterSpeed < -0.1)
        {
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2((textureOffSetX + backgroundSpeed), 0));
        }
	}
}

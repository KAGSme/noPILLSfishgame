using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform targetObject;
	private Vector3 velocity = Vector3.zero;
	public float dampTime = 0.3f;
	public float higherLimit;
	public float lowerLimit;
	
	void Update() {
		Vector3 currentXZPos = transform.position; 
		float currentY = transform.position.y;
		float newYPos = Mathf.Clamp(currentY, lowerLimit, higherLimit);
		transform.position = new Vector3(currentXZPos.x, newYPos, currentXZPos.z);
	}



	// Update is called once per frame
	void LateUpdate () {
		Vector3 viewPos = GetComponent<Camera>().WorldToViewportPoint(targetObject.position);
		Vector3 delta = targetObject.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, viewPos.z));
		Vector3 destination = transform.position + delta;
		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
	}
}

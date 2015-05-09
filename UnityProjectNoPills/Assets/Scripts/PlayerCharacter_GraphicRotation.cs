using UnityEngine;
using System.Collections;

public class PlayerCharacter_GraphicRotation : MonoBehaviour {

    public Transform parentObject;
    private Quaternion originalRotation;

	// Use this for initialization
	void Start () {
        originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
        if (parentObject.rotation.eulerAngles.z > 90 && parentObject.rotation.eulerAngles.z < 270)
        {
            transform.localRotation = Quaternion.Slerp(transform.rotation, new Quaternion(180,0,0,0),1);
        }
        if (parentObject.rotation.eulerAngles.z < 90 || parentObject.rotation.eulerAngles.z > 270)
        {
            transform.localRotation = Quaternion.Slerp(transform.rotation, originalRotation, 1); 
        }
	}
}

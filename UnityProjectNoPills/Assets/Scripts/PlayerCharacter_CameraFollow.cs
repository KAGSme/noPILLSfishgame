using UnityEngine;
using System.Collections;

public class PlayerCharacter_CameraFollow : MonoBehaviour {
    
    public Transform targetObject;
    private Vector3 targetDestination;
    public float dampTime = 0.3f;

    void Start()
    {
        targetDestination = new Vector3(0, 0, transform.position.z);
    }



    // Update is called once per frame
    void LateUpdate()
    {
        targetDestination.x = Mathf.Lerp(transform.position.x, targetObject.position.x, dampTime * Time.deltaTime);
        targetDestination.y = Mathf.Lerp(transform.position.y, targetObject.position.y, dampTime * Time.deltaTime);
        transform.position = targetDestination;
    }
}

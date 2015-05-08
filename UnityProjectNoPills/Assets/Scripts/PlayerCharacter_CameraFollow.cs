using UnityEngine;
using System.Collections;

public class PlayerCharacter_CameraFollow : MonoBehaviour {
    
    public Transform targetObject;
    private Vector3 targetDestination;
    /*public float deadzone = 0.5f;
    public float moveSpeed = 0.7f;
    public float deltaX = 0;
    public float deltaY = 0;*/


    void Start()
    {
        targetDestination = transform.position;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        /*if (targetObject.position.x > targetDestination.x)
        {
            deltaX = targetObject.position.x - transform.position.x;
        }
        if (targetObject.position.x < targetDestination.x)
        {
            deltaX = transform.position.x - targetObject.position.x;
        }
        if (deltaX > deadzone)
        {
            targetDestination.x = Mathf.Lerp(targetDestination.x, targetObject.position.x, moveSpeed * Time.deltaTime);
        }
        if (targetObject.position.y > targetDestination.y)
        {
            deltaY = targetObject.position.y - transform.position.y;
        }
        if (targetObject.position.y < targetDestination.y)
        {
            deltaY = transform.position.y - targetObject.position.y;
        }
        if (deltaY > deadzone)
        {
            targetDestination.y = Mathf.Lerp(targetDestination.y, targetObject.position.y, moveSpeed*Time.deltaTime);
        }*/

        targetDestination.x = targetObject.position.x;
        targetDestination.y = targetObject.position.y;
        transform.position = targetDestination;
    }
}

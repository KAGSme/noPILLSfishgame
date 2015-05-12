using UnityEngine;
using System.Collections;

public class PlayerCharacter_CameraFollow : MonoBehaviour {
    
    public Transform targetObject;
    //public float dampTime;
    public float topLimit;
    public float botLimit;
    public float rightLimit;
    public float leftLimit;
   // bool canMoveY = true;
    //private Vector3 velocity = Vector3.zero;
    private Vector3 targetDestination;

    void Start()
    {
        targetDestination = transform.position;
        targetDestination.y = targetObject.position.y;
        targetDestination.x = targetObject.position.x;
        transform.position = targetDestination;
    }

    // Update is called once per frame
    float timer;
    void LateUpdate()
    {
        if (targetObject.position.y < topLimit && targetObject.position.y > botLimit)
        {
            targetDestination.y = targetObject.position.y;
        }
        if (targetObject.position.x > leftLimit && targetObject.position.x < rightLimit)
        {
            targetDestination.x = targetObject.position.x;
        }

        transform.position = targetDestination;

       /* Vector3 point = Camera.main.WorldToViewportPoint(targetObject.position);
        Vector3 delta = Vector3.zero;
        if (targetObject.position.y < topLimit && targetObject.position.y > botLimit 
            && targetObject.position.x > leftLimit && targetObject.position.x < rightLimit)
        {
            delta = targetObject.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        }
        if (targetObject.position.x < leftLimit && targetObject.position.x > rightLimit && targetObject.position.y < topLimit && targetObject.position.y > botLimit)
        {
            delta = targetObject.position - Camera.main.ViewportToWorldPoint(new Vector3(point.x, 0.5f, point.z));
        }
        if (targetObject.position.y > topLimit && targetObject.position.y < botLimit && targetObject.position.x > leftLimit && targetObject.position.x < rightLimit)
        {
            delta = targetObject.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, point.y, point.z));
        }
        if (targetObject.position.x < leftLimit && targetObject.position.x > rightLimit && targetObject.position.y > topLimit && targetObject.position.y < botLimit)
        {
            delta = targetObject.position - Camera.main.ViewportToWorldPoint(new Vector3(point.x, point.y, point.z));
        }
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime * Time.deltaTime);*/
    }

}

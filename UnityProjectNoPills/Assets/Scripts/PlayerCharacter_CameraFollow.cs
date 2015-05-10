using UnityEngine;
using System.Collections;

public class PlayerCharacter_CameraFollow : MonoBehaviour {
    
    public Transform targetObject;
    public float topLimit;
    public float botLimit;
    private Vector3 targetDestination;
    bool canMoveY = true;

    void Start()
    {
        targetDestination = transform.position;
    }

    // Update is called once per frame
    float timer;
    void LateUpdate()
    {
        if (targetObject.position.y < topLimit && targetObject.position.y > botLimit)
        {
            targetDestination.y = targetObject.position.y;
        }
        targetDestination.x = targetObject.position.x;
        transform.position = targetDestination;
    }

   /* void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Level Edges")
        {
            Debug.Log("Can't move");
            canMove = false;
        }
    }*/
}

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

enum EnemyState { PATROLLING, CHASING, SEARCHING};

public class EnemyAI : MonoBehaviour {
    
    
    public Transform[] patrolWayPoints;
    public float patrolSpeed = 10f;
    public float chaseSpeed = 20f;
    public float chaseTime = 5f;
    public float patrolWaitTime = 1f;
    public float searchWaitTime = 5f;
    public bool patrolLoop;
    public int damageToPlayer;

    private GameObject player;
    private EnemyLineofSight elSight;
    private int wayPointIndex = 0;
    private int wayPointIterator = 1;
    private Transform TargetDestination;
    private EnemyState enemyState = EnemyState.PATROLLING;
    private Rigidbody2D rigidbodyThis;

	// Use this for initialization
	void Awake () {
        wayPointIndex = 0;
        rigidbodyThis = gameObject.GetComponent<Rigidbody2D>();
        elSight = GetComponentInChildren<EnemyLineofSight>();
        elSight.Rend.material.color = new Color32(160, 255, 170, 122);
	}
	
	// Update is called once per frame
	void Update () {
        switch(enemyState){
            case (EnemyState.PATROLLING):
                Patrolling();
                break;
            case (EnemyState.CHASING):
                Chasing();
                break;
            case (EnemyState.SEARCHING):
                Searching();
                break;
        }
	}

    float patrolWaitTimer = 0;
    void Patrolling()
    {
        if (elSight.PlayerInSight)
        {
            elSight.Rend.material.color = new Color32(255, 160, 160, 122);
            enemyState = EnemyState.CHASING;
        }
        TargetDestination = patrolWayPoints[wayPointIndex];
         if(DestinationCloseDistanceCheck())
         {
             patrolWaitTimer += Time.deltaTime;
             if (patrolWaitTimer >= patrolWaitTime)
             {
                 patrolWaitTimer = 0;
                 Debug.Log("Changing Destination");
                 if (wayPointIndex == (patrolWayPoints.Length - 1) && patrolLoop)
                 {
                     wayPointIndex = -1;
                 }
                 if (wayPointIndex == (patrolWayPoints.Length - 1) && !patrolLoop)
                 {
                     wayPointIterator = -1;
                 }
                 if (wayPointIndex == 0 && !patrolLoop)
                 {
                     wayPointIterator = 1;
                 }
                     wayPointIndex += wayPointIterator;
             }
         }
         else
         {
             MoveTowardsSimple(TargetDestination.position, patrolSpeed);
         }
    }

    float chaseTimer = 0;
    void Chasing()
    {
        player = elSight.Player;
        MoveTowardsSimple(player.transform.position, chaseSpeed);
        if (!elSight.PlayerInSight)
        {
            chaseTimer += Time.deltaTime;
            if (chaseTimer > chaseTime)
            {
                chaseTimer = 0;
                elSight.Rend.material.color = new Color32(255, 255, 160, 122);
                enemyState = EnemyState.SEARCHING;
            }
        }
    }
    float searchWaitTimer = 0;
    void Searching()
    {
        if (!elSight.PlayerInSight)
        {
            searchWaitTimer += Time.deltaTime;
            if (searchWaitTimer > searchWaitTime)
            {
                searchWaitTimer = 0;
                enemyState = EnemyState.PATROLLING;
                elSight.Rend.material.color = new Color32(160, 255, 170, 122);
            }
        }
        else 
        {
            elSight.Rend.material.color =  new Color32(255, 160, 160, 122);
            enemyState = EnemyState.CHASING; 
        }
    }

    void MoveTowardsSimple(Vector3 destination, float speed)
    {
        var direction = destination - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 8f * Time.deltaTime);

        rigidbodyThis.AddRelativeForce(new Vector2(patrolSpeed, 0));
    }

    bool DestinationCloseDistanceCheck()
    {
        if (Mathf.Abs(Vector3.Magnitude(TargetDestination.position - transform.position)) < 4.0f)
        {
            return true;
        }
        else return false;
    }

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < patrolWayPoints.Length; i++)
        {
            if (i != patrolWayPoints.Length - 1)
            {
                Gizmos.DrawLine(patrolWayPoints[i].position, patrolWayPoints[i+1].position);
            }
            if (i == patrolWayPoints.Length - 1 && patrolLoop)
            {
                Gizmos.DrawLine(patrolWayPoints[i].position, patrolWayPoints[0].position);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            coll.gameObject.GetComponent<PlayerCharacter_Health>().HealthDecrease(damageToPlayer);
        }
    }
}

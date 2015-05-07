using UnityEngine;
using System.Collections;

public class PlayerCharacter_Movement : MonoBehaviour {

    public float swimSpeed = 30f;
    public float swimBoost = 600f;
    public float maxSpeed = 5f;
    public float deadzone = 1f;
    private Vector3 mouseDirection;
    public float stamina = 100;
    public float staminaDrain = 10;
    public float staminRegain = 5;
    public float staminaWait = 2;
    private bool isDraining = false;
    private Rigidbody2D rigidbody;

    void Update()
    {
        var position = Camera.main.WorldToScreenPoint(transform.position);
        mouseDirection = Input.mousePosition - position;

        StaminaRegaining();

        if (DeadzoneCheck())
        {
            ObjectLookAtMouse();
        }
    }

    void FixedUpdate()
    {
        if (DeadzoneCheck())
        {
            MovementForce();
        }
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    //drains stamina
    void StaminaDraining()
    {
        isDraining = true;
        stamina -= staminaDrain;
    }

    //regains stamina after a certain amount of time
    float timer = 0;
    void StaminaRegaining()
    {
        if (stamina < 100)
        {
            if (isDraining)
            {
                timer += Time.deltaTime;
                if (timer >= staminaWait)
                {
                    isDraining = false;
                    timer = 0;
                }
            }
            if (!isDraining)
            {
                stamina += staminRegain * Time.deltaTime;
            }
        }
    }

    //applies a circular deadzone to the character
    bool DeadzoneCheck()
    {
        if (Vector3.Magnitude(mouseDirection)/ 50 > deadzone )
        {
            return true;
        }
        else return false;
    }

    //handles movement
    void MovementForce()
    {
        if (Input.GetButton("Fire1"))
        {
            rigidbody.AddRelativeForce(new Vector2(swimSpeed, 0));
        }
        if (Input.GetButtonDown("Fire2") && stamina > 0)
        {
            rigidbody.AddRelativeForce(new Vector2(swimBoost, 0));
            StaminaDraining();
        }
        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

    }

    //Orients camera to face cursor
    void ObjectLookAtMouse()
    {
     var angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
    }
}

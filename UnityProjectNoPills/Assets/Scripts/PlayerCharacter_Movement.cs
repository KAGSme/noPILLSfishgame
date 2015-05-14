using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCharacter_Movement : MonoBehaviour {

    public float swimSpeed = 30f;
    public float swimBoost = 600f;
    public float maxSpeed = 5f;
    public float deadzone = 1f;
    private Vector3 mouseDirection;
    private float stamina = 100;
    public float staminaDrain = 10;
    public float staminRegain = 5;
    public float staminaWait = 2;
    private bool isDraining = false;
    private Rigidbody2D rigidbodyThis;
    public Image staminaBar;

    float tapTimer = 0;
    int tapCount = 0;

    void Update()
    {
        var position = Camera.main.WorldToScreenPoint(transform.position);
        mouseDirection = Input.mousePosition - position;

        StaminaRegaining();
        StaminaUI();

        if (DeadzoneCheck())
        {
            ObjectLookAtMouse();
        }

        if (tapTimer > 0)
        {
            tapTimer -= Time.deltaTime; 
        }
        else { tapCount = 0; }
        if (Input.GetButtonDown("Fire1"))
        {
            tapTimer = 0.5f;
            tapCount += 1;
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
        rigidbodyThis = GetComponent<Rigidbody2D>();
    }

    //drains stamina
    void StaminaDraining()
    {
        isDraining = true;
        stamina -= staminaDrain;
    }

    void StaminaUI()
    {
        staminaBar.fillAmount = stamina / 100;
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
        Vector3 direction = new Vector3(Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x),
            Mathf.Abs(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y),
        0);

        if (direction.magnitude > deadzone)
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
            rigidbodyThis.AddRelativeForce(new Vector2(swimSpeed, 0));
        }
        if (((Input.GetButtonDown("Fire1") && tapCount >= 1) || Input.GetButtonDown("Fire2")) && stamina > 0)
        {
            rigidbodyThis.AddRelativeForce(new Vector2(swimBoost, 0));
            StaminaDraining();
        }
        if (rigidbodyThis.velocity.magnitude > maxSpeed)
        {
            rigidbodyThis.velocity = rigidbodyThis.velocity.normalized * maxSpeed;
        }

    }

    //Orients camera to face cursor
    void ObjectLookAtMouse()
    {
     var angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
    }

}

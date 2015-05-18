using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PlayerCharacter_Health : MonoBehaviour
{
    private float healthPoints = 100;
    public int healthPickUp = 33;
    public Image healthBar;
    private bool isInvisible = false;
    public float invincibiltyAfterHitTime = 1.0f;
    bool isInvincible = false;
    public float pillEffectTime = 5;
    Rigidbody2D rig;
    public GameObject illEffect;
    bool isHit;
    AudioSource audioSource;
    AudioClip hitClip;
    AudioClip healClip;

    public float HealthPoints
    {
        get { return healthPoints; }
    }
        
    public bool IsInvisible
    {
        get { return isInvisible; }
        set { isInvisible = value; }
    }

    void Awake()
    {
        healthPoints = 100;
        rig = GetComponent<Rigidbody2D>();
        hitClip = Resources.Load("Hit_Hurt") as AudioClip;
        healClip = Resources.Load("Powerup7") as AudioClip;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        var vortex = Camera.main.gameObject.GetComponent<Vortex>();
        vortex.enabled = false;
    }

    float damageTimer;
    void Update()
    {
        if (healthPoints > 100) healthPoints = 100;
        if (healthPoints < 0) healthPoints = 0;
        healthBar.fillAmount = healthPoints / 100;

        if (isHit)
        {
            GetComponentInChildren<Renderer>().material.color = Color.red;
            isInvincible = true;
            damageTimer += Time.deltaTime;
            if (damageTimer >= invincibiltyAfterHitTime)
            {
                damageTimer = 0;
                isInvincible = false;
                isHit = false;
                GetComponentInChildren<Renderer>().material.color = Color.white;
            }
        }

        if (effectIsOn)
        {
            effectTimer += Time.deltaTime;
            if (effectTimer > pillEffectTime)
            {
                var vortex = Camera.main.gameObject.GetComponent<Vortex>();
                var mb = Camera.main.GetComponent<MotionBlur>();
                vortex.enabled = false;
                mb.enabled = false;
                effectIsOn = false;
                effectTimer = 0;
            }
        }
        if (drunkIsOn)
        {
            illEffect.SetActive(true);
            drunkTimer += Time.deltaTime;
            rig.AddRelativeForce(new Vector2(Random.Range(-500, 500), Random.Range(-500, 500)));
            if (drunkTimer > pillEffectTime)
            {
                illEffect.SetActive(false);
                drunkIsOn = false;
                drunkTimer = 0;
            }
        }
    }

    public void HealthDecrease(int damage)
    {
        if (isInvincible == false) 
        {
            audioSource.PlayOneShot(hitClip);
            healthPoints -= damage;
            rig.AddRelativeForce(new Vector2(Random.Range(-400, 400), Random.Range(-400, 400)));
            isHit = true;
        }
    }

    public void HealthIncrease(int increase)
    {
        audioSource.PlayOneShot(healClip);
        if (healthPoints < 100) { healthPoints += increase; }
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == "Health Pick Up")
        {
            Destroy(coll.gameObject);
            HealthIncrease(healthPickUp);
        }
    }

    float effectTimer = 0;
    private bool effectIsOn = false;
    public bool EffectIsOn
    {
        get { return effectIsOn; }
        set { effectIsOn = value; }
    }
    float drunkTimer = 0;
    private bool drunkIsOn = false;
    public bool DrunkIsOn
    {
        get { return drunkIsOn; }
        set { drunkIsOn = value; }
    }
}

using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {

	public float health = 99f;
	public float regen = 5f;
	public int maxHealth = 100;
	public AudioClip DamageClip;
	public Texture HealthBar;

	// Update is called once per frame
	void Update () {
		 if (health <= 0) Application.LoadLevel(0);
		//regenerates 5 health per second
		if (health < maxHealth){ 
			health += regen * Time.timeScale;
		}
		//health stops regenerating when maxhealth is reached
        if (health > maxHealth) health = maxHealth;
	}

	public void Damage(float damageDealt){
		health-=damageDealt;
		GetComponent<AudioSource>().PlayOneShot(DamageClip);
	}

	void OnGUI(){
		GUI.DrawTexture(new Rect(20, 20, 200*(health/100), 50), HealthBar, ScaleMode.ScaleToFit, true, 0);
	}

}

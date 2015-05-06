using UnityEngine;
using System.Collections;

public class BulletPills : MonoBehaviour {

	public bool bulletFire;
	public GameObject bullet;
	public float lowerLimit;
	public float higherLimit;

	// Update is called once per frame
	void Update () {
		if(bulletFire){
			SpawnRandomPills();
		}
	}

	float timer = 0f;

	void SpawnRandomPills(){
		if(timer < Time.time){
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * Random.Range(0.1f,0.9f), Screen.height * 1.1f, 0f));
			Vector3 spawnPosition = ray.GetPoint( -ray.origin.z / Vector3.Dot(ray.direction,Vector3.forward));
			GameObject Target=(GameObject)Instantiate(bullet, spawnPosition, Quaternion.identity);
			timer = Time.time + Random.Range(lowerLimit, higherLimit);
		}
	}
}

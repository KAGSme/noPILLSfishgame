using UnityEngine;
using System.Collections;

public class PillSpawner : MonoBehaviour {

    public bool pillFire;
    public GameObject[] pillTypes;
    public float lowerLimit;
    public float higherLimit;
    Quaternion randomrotationZ;
    float random;

    // Update is called once per frame
    void Update()
    {
        if (pillFire)
        {
            SpawnRandomPills();
        }
    }

    float timer = 0f;

    void SpawnRandomPills()
    {
        if (timer < Time.time)
        {
            random = Random.Range(0, 360);
            randomrotationZ.SetAxisAngle(Vector3.forward, random);
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 1.1f, Screen.height * Random.Range(0.1f, 1f), 0f));
            Vector3 spawnPosition = ray.GetPoint(-ray.origin.z / Vector3.Dot(ray.direction, Vector3.forward));
            GameObject Target = (GameObject)Instantiate(pillTypes[Random.Range(0,3)], spawnPosition, randomrotationZ);
            timer = Time.time + Random.Range(lowerLimit, higherLimit);
        }
    }

}

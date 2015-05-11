using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

    public float timeToDestroy;
    public float sizeChange;
    private float timer;
    private Vector3 targetScale;

	// Use this for initialization
	void Start () {
        timer = 0;
        targetScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        targetScale.x += sizeChange * Time.deltaTime;
        targetScale.y += sizeChange * Time.deltaTime;
        transform.localScale = targetScale;
        timer += Time.deltaTime;
        if (timer >= timeToDestroy)
        {
            DestroyObject(gameObject);
        }
	}
}

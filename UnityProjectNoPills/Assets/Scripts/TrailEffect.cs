using UnityEngine;
using System.Collections;

public class TrailEffect : MonoBehaviour {

    void OnEnable()
    {
        GetComponent<TrailRenderer>().sortingLayerName = "ForeGround";
    }
	
	// Update is called once per frame
	void Update () {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0;
        transform.position = position;

        if (Input.GetButtonUp("Fire1"))
        {
            Destroy(gameObject);
        }
	}
}

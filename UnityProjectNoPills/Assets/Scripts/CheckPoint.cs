using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

    private bool used = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !used)
        {
            used = true;
            GameData.gameData.ChangeCheckPoint(other.gameObject.transform.position);
        }
    }
}

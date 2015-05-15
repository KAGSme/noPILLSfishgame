using UnityEngine;
using System.Collections;

public enum gameState { PLAYING , PAUSE };

public class GameControl_MAIN : MonoBehaviour {

    public static GameControl_MAIN gameControl;
    public GameObject player;
    private PlayerCharacter_Health playerHealth;
    public bool isPaused;

    void OnEnable()
    {
        if (gameControl == null)
        {
            gameControl = this;
        }
        else { DestroyObject(gameObject); }
    }

	// Use this for initialization
	void Start () {
        if(GameData.gameData.CheckPoint != null){
            player.transform.position = GameData.gameData.CheckPoint;
        }
        playerHealth = player.GetComponent<PlayerCharacter_Health>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth.HealthPoints <= 0)
        {
            Debug.Log("restart");
            Application.LoadLevel(Application.loadedLevel);
        }
	}


}

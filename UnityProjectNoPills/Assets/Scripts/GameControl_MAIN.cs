using UnityEngine;
using System.Collections;

public enum gameState { PLAYING , PAUSE };

public class GameControl_MAIN : MonoBehaviour {

    public static GameControl_MAIN gameControl;
    public GameObject player;
    private PlayerCharacter_Health playerHealth;
    public bool isPaused;
    public GameObject trailEffect;
    AudioSource audioSource;

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
        if (!GameData.gameData.LevelStart)
        {
            Debug.Log("LevelReset");
            GameControl_MAIN.gameControl.player.transform.position = GameData.gameData.CheckPoint;
        }
        playerHealth = player.GetComponent<PlayerCharacter_Health>();
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
        PlayMainMusic();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth.HealthPoints <= 0)
        {
            Debug.Log("restart");
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(trailEffect, transform.position, transform.rotation);
        }

        if (GameData.gameData.AudioIsOn)
        {
            AudioListener.volume = 1;
        }
        else AudioListener.volume = 0;
	}

    public void Pause()
    {
        isPaused = true;

        if (isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void UnPause()
    {
        isPaused = false;

        if (isPaused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void Mute()
    {
        GameData.gameData.AudioIsOn = !GameData.gameData.AudioIsOn;
        AudioListener.pause = !GameData.gameData.AudioIsOn;
    }

    public void LoadLevel(string LevelName)
    {
        GameData.gameData.LevelStart = true;
        Debug.Log("Ltrue");
        Application.LoadLevel(LevelName);
    }

    public void PlayChaseMusic()
    {
        audioSource.Play();
        Debug.Log("CHASE");
        Camera.main.GetComponent<AudioSource>().Pause();
    }

    public void PlayMainMusic()
    {
        audioSource.Pause();
        Debug.Log("PATROL");
        Camera.main.GetComponent<AudioSource>().UnPause();
    }

}

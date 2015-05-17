using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    public static GameData gameData;
    public Vector3 checkPoint;
    public bool levelStart = true;
    public bool audioIsOn = true;

    void Start()
    {
        Debug.Log("Start");
        if (levelStart && Application.loadedLevelName != "MainMenu" && Application.loadedLevelName != "LevelSelect" && Application.loadedLevelName != "LanguageMenu")
        {
            Debug.Log("levelStart");
            checkPoint = GameControl_MAIN.gameControl.player.transform.position;
            levelStart = false;
        }
        AudioListener.pause = !audioIsOn;
    }

    void OnLevelWasLoaded(int Level)
    {
        Debug.Log("Start");
        if (levelStart && Application.loadedLevelName != "MainMenu" && Application.loadedLevelName != "LevelSelect" && Application.loadedLevelName != "LanguageMenu")
        {
            Debug.Log("levelStart");
            checkPoint = GameControl_MAIN.gameControl.player.transform.position;
            levelStart = false;
        }
        AudioListener.pause = !audioIsOn;
    }

    public bool LevelStart
    {
        get { return levelStart; }
        set { levelStart = value; }
    }

    public Vector3 CheckPoint
    {
        get { return checkPoint; }
        set { checkPoint = value; }
    }

    public bool AudioIsOn
    {
        get { return audioIsOn; }
        set { audioIsOn = value; }
    }

    void Update()
    {

    }

    public void ChangeCheckPoint(Vector3 checkpointNew)
    {
        checkPoint = checkpointNew;
        Debug.Log("checkpoint");
    }  

    void OnEnable()
    {
        if (gameData == null)
        {
            gameData = this;
            DontDestroyOnLoad(gameObject);
        }
        else { DestroyObject(gameObject); }
    }

}

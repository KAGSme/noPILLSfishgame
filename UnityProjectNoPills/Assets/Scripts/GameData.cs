using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    public static GameData gameData;
    private Vector3 checkPoint;
    private bool levelStart = true;
    private bool audioIsOn;

    void Start()
    {
        if (levelStart)
        {
            checkPoint = GameControl_MAIN.gameControl.player.transform.position;
            levelStart = false;
        }
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
        if (levelStart)
        {
            CheckPoint = GameControl_MAIN.gameControl.player.transform.position;
            levelStart = false;
        }
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

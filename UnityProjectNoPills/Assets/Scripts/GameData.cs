using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    public static GameData gameData;
    private Vector3 checkPoint;
    private bool audioIsOn;

    void Start()
    {
        if (checkPoint == null)
        {
            checkPoint = GameControl_MAIN.gameControl.player.transform.position;
        }
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
        if (CheckPoint == null)
        {
            CheckPoint = GameControl_MAIN.gameControl.player.transform.position;
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

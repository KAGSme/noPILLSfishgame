using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    void Start()
    {
        Time.timeScale = 1;
    }

    public void LoadLevel(string levelName)
    {
        GameData.gameData.LevelStart = true;
        Application.LoadLevel(levelName);
    }

    public void Mute()
    {
        GameData.gameData.AudioIsOn = !GameData.gameData.AudioIsOn;

        if (GameData.gameData.AudioIsOn) AudioListener.volume = 1;
        else AudioListener.volume = 0;
    }
    
}

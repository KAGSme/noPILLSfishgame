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
        AudioListener.pause = !GameData.gameData.AudioIsOn;
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().PlayOneShot(Resources.Load("water menu noise") as AudioClip);
    }
    
}

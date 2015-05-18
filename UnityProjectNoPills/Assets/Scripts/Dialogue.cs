using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public string[] linesOfDialogue;
    private bool dialogue = false;
    private bool used = false;
    public GameObject DialogueBox;
    public GameObject textObject;
    public bool loadsNextLevel = false;
    public string nextLevel;
    Text textComponent;
    int iterator = 0;
    public Texture btnTexture;

    void Awake()
    {
        textComponent = textObject.GetComponent<Text>();
    }

    void Update()
    {
        if (dialogue)
        {
            if (iterator >= linesOfDialogue.Length)
            {
                dialogue = false;
                DialogueState();
                GameControl_MAIN.gameControl.UnPause();
                if(loadsNextLevel) GameControl_MAIN.gameControl.LoadLevel(nextLevel);
            }
            if (dialogue)
            {
                textComponent.text = LanguageScriptLoader.languageManager.LoadString(linesOfDialogue[iterator]);
            }
        }
    }

    public void Iterate()
    {
        if (iterator < linesOfDialogue.Length)
        {
            iterator++;
        }
    }

    void DialogueState()
    {
        DialogueBox.SetActive(dialogue);
        textObject.SetActive(dialogue);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !used)
        {
            GameControl_MAIN.gameControl.Pause();
            dialogue = true;
            used = true;
            DialogueState();
            textComponent.text = LanguageScriptLoader.languageManager.LoadString(linesOfDialogue[iterator]);
        }
    }

    void OnGUI()
    {
        if (dialogue)
        {
            if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 150, 100, 100), btnTexture))
            {
                Iterate();
            }
        }
    }
}

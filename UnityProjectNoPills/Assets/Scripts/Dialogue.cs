using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public string[] linesOfDialogue;
    private bool dialogue = false;
    private bool used = false;
    public GameObject DialogueBox;
    public GameObject textObject;
    Text textComponent;
    int iterator = 0;

    void Awake()
    {
        textComponent = textObject.GetComponent<Text>();
    }

    void Update()
    {
        if (dialogue)
        {
            if (Input.GetButtonDown("Fire1") && iterator < linesOfDialogue.Length)
            {
                iterator++;
            }
            if (iterator >= linesOfDialogue.Length)
            {
                dialogue = false;
                DialogueState();
                GameControl_MAIN.gameControl.UnPause();
            }
            if (dialogue)
            {
                textComponent.text = LanguageScriptLoader.languageManager.LoadString(linesOfDialogue[iterator]);
            }
        }
    }

    void DialogueState()
    {
        DialogueBox.SetActive(dialogue);
        textObject.SetActive(dialogue);
    }

    void OnTriggerEnter2D(Collider2D other)
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
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public string[] linesOfDialogue;
    private bool dialogue;
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
                textComponent.text = LanguageScriptLoader.languageManager.LoadString(linesOfDialogue[iterator]);
            }
            if (iterator > linesOfDialogue.Length)
            {
                dialogue = false;
                DialogueState();
            }
        }
    }

    void DialogueState()
    {
        textObject.SetActive(dialogue);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogue = true;
            DialogueState();
            textComponent.text = LanguageScriptLoader.languageManager.LoadString(linesOfDialogue[iterator]);
        }
    }
}

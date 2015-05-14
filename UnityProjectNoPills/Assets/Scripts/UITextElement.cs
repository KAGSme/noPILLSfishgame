using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextElement : MonoBehaviour {

    Text text;
    public string textElement;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = LanguageScriptLoader.languageManager.LoadString(textElement);
	}
}

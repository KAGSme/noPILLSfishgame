using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;

public enum Languages { ENGLISH, GERMAN};

public class LanguageScriptLoader : MonoBehaviour {

    public static LanguageScriptLoader languageManager;
    public Languages language = Languages.ENGLISH;

    XmlDocument xmlDoc = new XmlDocument();
    string languageString = "English";

    void OnEnable()
    {
        if (languageManager == null)
        {
            languageManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        SetLanguage(language);
        TextAsset textAsset = (TextAsset)Resources.Load("GameScript", typeof(TextAsset));
        xmlDoc.LoadXml(textAsset.text);
    }

    public void SetLanguage(Languages languageNew)
    {
        language = languageNew;
        switch (language)
        {
            case Languages.ENGLISH:
                languageString = "English";
                break;
            case Languages.GERMAN:
                languageString = "German";
                break;
        }
    }

    public void SetLanguage(string languageNew)
    {
        Debug.Log("L set");
        languageString = languageNew;
        switch (languageString)
        {
            case "English":
                language = Languages.ENGLISH;
                break;
            case "German":
                language = Languages.GERMAN;
                break;
        }
    }

    public string LoadString(string stringName)
    {
        XmlNodeList languageList = xmlDoc.GetElementsByTagName(languageString);
        foreach (XmlNode languageNode in languageList)
        {
            XmlNodeList languageItems = languageNode.ChildNodes;
            foreach (XmlNode lContent in languageItems)
            {
                if (lContent.Name == stringName)
                {
                    return lContent.InnerText.ToString();
                }
            }
        }
        
    return "ERROR: MISSING TEXT ELEMENT";
    }
}

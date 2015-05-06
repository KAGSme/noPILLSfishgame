using UnityEngine;
using System.Collections;

public class EndMenuScript : MonoBehaviour 
{
	public GUISkin guiSkin;
	public Texture2D background, LOGO;
	public bool DragWindow = false;
	public AudioClip ForwardButton;
	public AudioClip BackButton;
	
	public string[] AboutTextLines = new string[0];
	
	
	private string clicked = "", MessageDisplayOnAbout = "\n\n\n\n About \n ";
	private Rect WindowRect = new Rect((Screen.width / 2) - 175, Screen.height / 2, 350, 100);
	private float volume = 1.0f;
	
	private void Start()
	{
		for (int x = 0; x < AboutTextLines.Length;x++ )
		{
			MessageDisplayOnAbout += AboutTextLines[x] + " \n ";
		}
		MessageDisplayOnAbout += "Press Esc To Go Back \n This game was created at noPills Game Jam to raise awareness " +
			"for the disposal of medical \n waste properly without damaging the environment.\n\n Credits: \n" +
				"Mark Tempini - Designer & Programmer & Audio \n Andrew Graham - Designer & Programmer \n Farhad Chamo - Designer \n Kieran Gallagher - Lead Programmer \n Réka Lux - Artist \n Mihael Galchev - Artist";
		
		
	}
	
	private void OnGUI()
	{
		if (background != null)
			GUI.DrawTexture(new Rect(0,0,Screen.width , Screen.height),background);
		if (LOGO != null && clicked != "about")
			GUI.DrawTexture(new Rect((Screen.width / 2) - 100, 30, 200, 200), LOGO);
		
		GUI.skin = guiSkin;
		if (clicked == "")
		{
			WindowRect = GUI.Window(0, WindowRect, menuFunc, "");
		}
		else if (clicked == "options")
		{
			WindowRect = GUI.Window(1, WindowRect, optionsFunc, "");
		}
		else if (clicked == "about")
		{
			GUI.Box(new Rect (0,0,Screen.width,Screen.height), MessageDisplayOnAbout);
		}else if (clicked == "resolution")
		{
			GUILayout.BeginVertical();
			for (int x = 0; x < Screen.resolutions.Length;x++ )
			{
				if (GUILayout.Button(Screen.resolutions[x].width + "X" + Screen.resolutions[x].height))
				{
					Screen.SetResolution(Screen.resolutions[x].width,Screen.resolutions[x].height,true);
				}
			}
			GUILayout.EndVertical();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Back"))
			{
				clicked = "options";
			}
			GUILayout.EndHorizontal();
		}
	}
	
	private void optionsFunc(int id)
	{
		if (GUILayout.Button("Resolution"))
		{
			clicked = "resolution";
			GetComponent<AudioSource>().PlayOneShot(ForwardButton);
			
		}
		GUILayout.Box("Volume");
		volume = GUILayout.HorizontalSlider(volume ,0.0f,1.0f);
		AudioListener.volume = volume;
		if (GUILayout.Button("Back"))
		{
			clicked = "";
			GetComponent<AudioSource>().PlayOneShot(BackButton);
			
		}
		if (DragWindow)
			GUI.DragWindow(new Rect (0,0,Screen.width,Screen.height));
	}
	
	private void menuFunc(int id)
	{
		if (GUILayout.Button("Main Menu"))
		{
			Application.LoadLevel(0);
			GetComponent<AudioSource>().PlayOneShot(ForwardButton);
		}

		if (GUILayout.Button("Quit"))
		{
			Application.Quit();
			GetComponent<AudioSource>().PlayOneShot(BackButton);
		}
		
		if (DragWindow)
			GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
	}
	
	private void Update()
	{
		if (clicked == "about" && Input.GetKey (KeyCode.Escape))
			clicked = "";
	}
}
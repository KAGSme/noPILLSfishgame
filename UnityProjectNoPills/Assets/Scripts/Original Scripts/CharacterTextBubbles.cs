using UnityEngine;
using System.Collections;

public class CharacterTextBubbles : MonoBehaviour {

	public GUISkin guiSkin;
	public bool DrawBubble = false;
	public int length;
	public string[] textContent = new string[4];
	public bool[] frogONgui = new bool[4];
	private bool next;
	public Texture frogAvatar;

	void Start(){
		DrawBubble = false;
	}

	void Update(){
		if(Input.GetButtonDown("next")){
			next = true;
		}
	}

	void OnGUI(){

		if (guiSkin != null) {
			GUI.skin = guiSkin;
		}
		
		GameObject player = GameObject.FindWithTag("MainCamera");
		BulletPills script = (BulletPills)player.GetComponent(typeof(BulletPills));
		int i = 0;
		if(i<length){
			if(DrawBubble){
			
				Debug.Log("Cutscene");
				script.bulletFire = false;
					next = true;
					
				if(next){
					Debug.Log("Drawing");
					GUI.Box(new Rect(Screen.width/3+5, Screen.height/10, Screen.width/4 , Screen.height/4), textContent[i]);
					if (frogONgui[i]) GUI.DrawTexture(new Rect(10, 10, 60, 60), frogAvatar, ScaleMode.ScaleToFit, true, 10.0F);
					i++;
				}

				next = false;

				if(i == length-1){
					script.bulletFire = true;
					DrawBubble = false;
				}
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	void OnGUI () {
		GUI.backgroundColor = Color.yellow;
		if (GUI.Button (new Rect (Screen.width/2+130,Screen.height-130,150,70), "PLAY")) {
			Application.LoadLevel("INfinity_Board");
		}
		
		if (GUI.Button (new Rect (Screen.width/2-170,Screen.height/2-215,120,30), "Reset Hiscore")) {
			ScoreManager.Instance.DeleteHighscore();
		}
	}
}
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	private static ScoreManager instance;
	
	public int currentScore=0;
	private bool newGame = true;
	public bool hasToLevelUp = false;
	private float gametime;
	
	
	public static ScoreManager Instance
	{
		get {
	         if(instance == null) {
			    GameObject g = new GameObject ("ScoreObject");
			    instance = g.AddComponent<ScoreManager> ();
			    DontDestroyOnLoad(g);
			}
	         return instance;
		}
	}


	
	public bool GameEnded() {
		newGame = false;
		
		if(PlayerPrefs.GetInt("highscore") < currentScore)
			{
				PlayerPrefs.SetInt("highscore", currentScore);
				return true;
			}
		
		return false;
	}

	public void NewGame(){
		currentScore=0;
		newGame = true;
		gametime = 0.0f;
	}
	
	public void AddScore() {
		currentScore+=1;
		if ( currentScore  % 10 == 0 && currentScore!=0)
			hasToLevelUp = true;
	}
	
	public int GetHighscore() {
		return 	PlayerPrefs.GetInt("highscore");
	}
	public void DeleteHighscore() {
		PlayerPrefs.SetInt("highscore", 0);
	}
	
	void OnGUI()
	{ 
  		
		GUI.skin.label.fontSize = 20;
		if(newGame == true)
		{
			GUI.Label(new Rect(110,0,200,100), "Hiscore: " + GetHighscore ().ToString());
			GUI.Label(new Rect(10,0,100,100), "Score: " + currentScore.ToString());
		}
		
			
	}
	
	void Update ()	
	{
		if(newGame)
		gametime+=Time.deltaTime;
	}
	
	public float getGametime()
	{
		return gametime;	
	}
}

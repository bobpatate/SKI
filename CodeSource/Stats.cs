using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	private float playerForce = 5f;
	private float playerPoid = 1.0f;
	private float enemyForce = 1.5f;
	private float enemyPoid = 1.0f;
	private bool displayLevelUp = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreManager.Instance.hasToLevelUp)
		{
			Debug.Log ("Avant de rentrer dans LevelUp");
			ScoreManager.Instance.hasToLevelUp = false;
			PlayerLevelUp();
		}
			
	}
	
	public float getPlayerAttackRatio()
	{
		return playerForce/(enemyPoid + (ScoreManager.Instance.getGametime() / 10) * 0.1f);
	}
	
	public float getPlayerDefenseRatio()
	{
		return (enemyForce + (ScoreManager.Instance.getGametime() / 10) * 0.1f) / playerPoid;
	}
	
	
	void PlayerLevelUp()
	{
		displayLevelUp = true;
		Invoke("stopLevelMessageDisplay",3);
		playerForce += 0.15f;
		playerPoid += 0.15f;
		
	}
	
	void stopLevelMessageDisplay()
	{
		displayLevelUp = false;
	}
	
	void OnGUI()
	{
		if ( displayLevelUp )
			GUI.Label(new Rect(300,0,400,100),"LEVEL UP !");
	}
}

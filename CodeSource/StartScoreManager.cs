using UnityEngine;
using System.Collections;

public class StartScoreManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ScoreManager.Instance.NewGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

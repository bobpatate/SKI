using UnityEngine;
using System.Collections;

public class killZ : MonoBehaviour {
	
	private Generator scriptGenerator;
	public AudioClip wilelhm;

	void Start (){
		
		GameObject generatorObject = GameObject.Find("Generator1");
		scriptGenerator = (Generator)generatorObject.GetComponent("Generator");
	}
	
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) { 	
		if(other.gameObject.tag == "Player"){
			ScoreManager.Instance.GameEnded();
			audio.PlayOneShot(wilelhm);
			Invoke ("LoadLevel", 2);
		}
		
		if(other.gameObject.tag == "Enemy"){
			ScoreManager.Instance.AddScore();
			scriptGenerator.DecreaseCountEnemy();
			
			Destroy (other);
		}
	}
	
	void LoadLevel(){
		Application.LoadLevel(0);
	}
}
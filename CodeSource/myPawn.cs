using UnityEngine;
using System.Collections;

public class myPawn : MonoBehaviour{
	
	public AudioClip wooshSound;
	
	private SpriteSheet script;
	public GameObject Perso;
	private PlayerAttack PA; 

	void Start (){
		GameObject perso = GameObject.Find("Perso");
		script = (SpriteSheet)perso.GetComponent("SpriteSheet");
		PA = (PlayerAttack)Perso.GetComponent("PlayerAttack");
	}
	
	public float speed = 10.0f;
		
	void Update () {
		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		float vertMov = Input.GetAxis ("Vertical") * speed;
		float horMov = Input.GetAxis ("Horizontal") * speed;
		
		// Make it move 10 meters per second instead of 10 meters per frame...
		vertMov *= Time.deltaTime;
		horMov *= Time.deltaTime;
		
		//velocity vector
		Vector3 velocity = new Vector3(horMov, 0, vertMov);
		
		// Move translation along the object's z-axis
		rigidbody.AddForce(velocity);
		
		//Attaques
		if(Input.GetMouseButtonDown(0)&& PA.attackTimer == 0 )//Left click
			startAttLeft();
		if(Input.GetMouseButtonDown(1)&& PA.attackTimer == 0 )//Right click
			startAttRight();
	}
		
		
	void startAttLeft(){
		audio.PlayOneShot(wooshSound);
		script.etat = 1;
	
		if(Input.GetMouseButtonUp(0))
			stopAttLeft();
	}
	
	void startAttRight(){
		audio.PlayOneShot(wooshSound);
		script.etat = 2;
	
		if(Input.GetMouseButtonUp(1))
			stopAttRight();
	}
	
	
	void stopAttLeft(){
		script.etat = 0;
	}
	
	void stopAttRight(){
		script.etat = 0;
	}
		
}
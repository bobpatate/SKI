using UnityEngine;
using System.Collections;

public class bacorneMove : MonoBehaviour {
	
	Vector3 position;
	public float speed = 1.0f;
	
	// Use this for initialization
	void Start () {
		position = new Vector3(0,0,0)-transform.position;
		position= new Vector3(transform.position.x,0,transform.position.z);
		position.Normalize ();
		
		transform.LookAt(position);
		transform.Rotate (new Vector3(0,1,0), -90f);
		
		Invoke ("DeleteBacorne", 9.0f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= (position*speed);
	}
	
	void DeleteBacorne(){
		DestroyObject(this.gameObject);
	}
}

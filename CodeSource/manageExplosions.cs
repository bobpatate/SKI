using UnityEngine;
using System.Collections;

public class manageExplosions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("deleteExplosion",0.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void deleteExplosion()
	{
		Destroy(this.gameObject);
	}
}

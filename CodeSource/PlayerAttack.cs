using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject leftArmScript;
	public GameObject rightArmScript;
	public float attackTimer;
	private float coolDown;
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		coolDown = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {
		if(attackTimer > 0)
		{
			attackTimer -= Time.deltaTime;
		}
		
		if (attackTimer < 0)
			attackTimer = 0;
		
		if(Input.GetMouseButtonDown(0))
		{
			if (attackTimer == 0){
				ArmAttack aa = (ArmAttack)leftArmScript.GetComponent("ArmAttack");
				attackTimer = coolDown;
				aa.toggleAttack();
			}
				
		}
		if(Input.GetMouseButtonDown(1))
		{
			if (attackTimer == 0){
				ArmAttack aa = (ArmAttack)rightArmScript.GetComponent("ArmAttack");
				attackTimer = coolDown;
				aa.toggleAttack();
			}
				
		}
	}
	
}


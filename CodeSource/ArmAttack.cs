using UnityEngine;
using System.Collections;

public class ArmAttack : MonoBehaviour {
	private bool isAttacking;
	private bool isColliding;
	public bool currentZDirection;
	private float force = 200.0f; 
	private float attackAnimationTimer;
	private float coolDownAnimation = 0.15f;
	public float forceModifier;
	private Stats PS;
	public GameObject Perso;
	
	public AudioClip boomSound;
	
	// Use this for initialization
	void Start () {
		PS = (Stats)Perso.GetComponent("Stats");
		isAttacking = false;
		isColliding = false;
		attackAnimationTimer = 0;
		if ( currentZDirection )
		{
			force = -force;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if ( isAttacking )
		{
			if ( attackAnimationTimer < coolDownAnimation)
				attackAnimationTimer += Time.deltaTime;
			else if (attackAnimationTimer == 0)
				attackAnimationTimer = coolDownAnimation;
			else
			{
				attackAnimationTimer = 0;
				isColliding = true;
				toggleAttack();
			}
						
		}
		else if(isColliding)
			isColliding = false;
		
			
			
		
	}
	
	public void toggleAttack()
	{
		isAttacking = !isAttacking;
	}
	
	void OnTriggerStay(Collider other)
	{
		if ( isColliding == true && other.tag == "Enemy" )
		{
			audio.PlayOneShot(boomSound);
			other.rigidbody.AddForce(new Vector3(0,0,1) * force * PS.getPlayerAttackRatio());
		}
	}
}



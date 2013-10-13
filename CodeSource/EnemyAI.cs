using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	
	private Transform playerPos;
	private Vector3 targetDirection;
	private float maxVelocity = 5.0f;
	private int force = 1000;
	private int moveSpeed = 1000;
	private float zOffset=1.0f;
	private Vector3 Offset;
	GameObject go;
	bool inAttackZone;
	
	public float weightModifier;
	private Stats PS;
	
	
	public AudioClip hitSound;
	
	private float EnemyStrengthRatio=0.4f;
	private float EnemyKnockbackRatio=1.5f;
	
	
	private Transform myTransform; //Cache the transform so it doesnt recalculate every update
	
	void Awake()
	{
		myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		go = GameObject.FindGameObjectWithTag("Player");
		PS = (Stats)go.GetComponent("Stats");
		//maxVelocity = 20.0f;
		inAttackZone=false;
		Offset= new Vector3(0,0,zOffset);
		
	}
	
	// Update is called once per frame
	void Update () {
		;
		if (inAttackZone==false)
		{
			if ( Mathf.Sqrt(Mathf.Pow(rigidbody.velocity.x,2) + Mathf.Pow(rigidbody.velocity.x,2)) <= maxVelocity )
			{
				playerPos = go.transform;
				if (playerPos.position.z < 0)
				{
					targetDirection = (playerPos.position - myTransform.position)+ Offset;
				}
				else
				{
					targetDirection = (playerPos.position - myTransform.position)- Offset;
				}
				
				
				
				targetDirection= new Vector3(targetDirection.x, 0, targetDirection.z);
				targetDirection.Normalize();
				rigidbody.AddForce(targetDirection * force * Time.deltaTime);
			}
		}
		else
		{
			playerPos = go.transform;
			targetDirection = (playerPos.position - myTransform.position);
			targetDirection= new Vector3(targetDirection.x, 0, targetDirection.z);
			targetDirection.Normalize();
			rigidbody.AddForce(targetDirection * force * Time.deltaTime * 1.5f);
		}
	}
	
	void OnTriggerEnter(Collider other) {
        if (other.tag=="PlayerAttackZone")
		{
			inAttackZone=true;	
		}
    }
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag=="Player")
		{
			audio.PlayOneShot(hitSound);
			playerPos = go.transform;
			targetDirection = (myTransform.position- playerPos.position);
			targetDirection= new Vector3(targetDirection.x, 0, targetDirection.z);
			targetDirection.Normalize();
			rigidbody.AddForce(targetDirection * force *EnemyKnockbackRatio * 0.5f);         //Knockback de l'ennemi a cause du tackle
			targetDirection= new Vector3(-targetDirection.x, 0, -targetDirection.z);
			go.rigidbody.AddForce(targetDirection * force *EnemyStrengthRatio * PS.getPlayerDefenseRatio());     //L'ennemi attaque le player
			
			GameObject temp = Instantiate(Resources.Load ("Small explosion"))as GameObject;
			temp.transform.position= collision.contacts[0].point + new Vector3(0,1,0);
			
		}
	}
}

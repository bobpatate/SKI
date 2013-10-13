using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	
	private float count = 0.0f;
	public float spawnDelay = 3.0f;
	public int enemyCount = 0;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(15, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(count <= 0){
			float random = Random.seed;
			random = Random.Range(-2.2f, 3.7f);
			
			GameObject go;
			
			
			if(Random.value <= .03){//Spawn licorne
				go = Instantiate(Resources.Load("Bacorn")) as GameObject;
				
				float x = Random.Range(-10.0f, 10.0f);
				float z = Mathf.Sqrt(100-Mathf.Pow(x, 2f));
				if(Random.value <= .5)
					z = -z;
				
				go.transform.position = new Vector3(x, -0.5f, z);
			}
			
			else if(enemyCount <= Mathf.RoundToInt(Mathf.Sqrt (ScoreManager.Instance.getGametime()) / 2)){//Spawn ennemi		
				go = Instantiate(Resources.Load("Enemy")) as GameObject;
				
				if(Random.value <= .5){
					go.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+random);
				}
				else{
					go.transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z+random);
				}
				
				enemyCount++;
			}

			count = spawnDelay;
		}
		else{
			count -= Time.deltaTime;
		}
	}
	
	public void DecreaseCountEnemy(){
		enemyCount--;
	}
}

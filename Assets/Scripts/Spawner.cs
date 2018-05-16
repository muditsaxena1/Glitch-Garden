using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	public float startSpawningAfterSec = 10f;
	public float difficulty = 3f;

	private float threshold1 = 0,threshold2 = 0;
	[SerializeField()]
	private bool startSpawing = false;

	void Start(){
		Invoke ("SetStartSpawingToTrue", startSpawningAfterSec);
		foreach (GameObject thisAttacker in attackerPrefabArray){
			if (difficulty == 1f){
				thisAttacker.GetComponent<Attacker>().seenEverySecond = 10f;
			}
			else if (difficulty == 2f){
				thisAttacker.GetComponent<Attacker>().seenEverySecond = 7f;
			}
		}   
	}

	void SetStartSpawingToTrue(){
		startSpawing = true;
	}
	void Update(){
		if (startSpawing){
			foreach (GameObject thisAttacker in attackerPrefabArray){
				if (isTimeToSpawn(thisAttacker)){
					Spawn(thisAttacker);
				}
			}   
		}
	}
	
	void Spawn (GameObject myGameObject){
		GameObject newGameObject = Instantiate(myGameObject, this.transform.position, Quaternion.identity) as GameObject;
		newGameObject.transform.parent = this.transform;
	}

	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();

		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}

		float threshold = spawnPerSecond * Time.deltaTime / 5;

		return (Random.value < threshold);
	}

	//use this function also. Called from Update()
	bool isTimeToSpawn2(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		
		float meanSpawnDelay = attacker.seenEverySecond;
		float spawnPerSecond = 1 / meanSpawnDelay;
		
		if (Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		if (attacker.name == "Fox"){
			threshold1 += spawnPerSecond * Time.deltaTime / 5;
			
			if (Random.value < threshold1){
				threshold1--;
				return true;
			}
		}
		else{
			threshold2 += spawnPerSecond * Time.deltaTime / 5;
			
			if (Random.value < threshold2){
				threshold2--;
				return true;
			}
		}

		return false;
	}
}

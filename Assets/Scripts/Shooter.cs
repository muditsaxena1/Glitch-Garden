using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	
	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator anim;
	private Spawner myLaneSpawner;


	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}

	void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		foreach (Spawner currSpawner in spawnerArray){
			if (currSpawner.transform.position.y == this.transform.position.y){
				myLaneSpawner = currSpawner;
				return;
			}
		}
		Debug.LogError("Could not find the corresponding spawner for this shooter!!");
	}
	
	// Update is called once per frame
	void Update () {
		if (IsAttackerAheadInLane()){
			anim.SetBool("isAttacking", true);
		}
		else{
			anim.SetBool("isAttacking", false);
		}
	}
	bool IsAttackerAheadInLane(){
		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		// if atleast one attacker is ahead
		foreach(Transform attacker in myLaneSpawner.transform){
			if (attacker.position.x > this.transform.position.x){
				return true;
			}
		}
		//if all attackers are behind
		return false;
	}
	private void Fire(){
		GameObject newProjectile = Instantiate(projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D collider){
		GameObject obj = collider.gameObject;
		if(!obj.GetComponent<Attacker>()){
			return;
		}
		Health health = obj.GetComponent<Health>();
		if(!health){
			Debug.LogError(obj.name + " has no Heath component attached to it");
			return;
		}
		health.DealDamage(damage);
		Destroy(this.gameObject);
	}
}



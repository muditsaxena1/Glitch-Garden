using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]

public class Lizard : MonoBehaviour {
	private Animator anim;
	private Attacker attacker;
	
	void Start () {
		anim = this.GetComponent<Animator>();
		attacker = this.GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		if(!obj.GetComponent<Defender>()){
			return;
		}
		//Attack
		anim.SetBool("isAttacking", true);
		attacker.Attack(obj);

	}
}

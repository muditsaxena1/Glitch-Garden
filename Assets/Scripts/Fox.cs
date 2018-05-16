using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Attacker))]

public class Fox : MonoBehaviour {
	private Animator anim;
	private Attacker attacker;
	private bool jumpedOnce = false;
	
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

		if(obj.GetComponent<Stone>() && !jumpedOnce){
			//Jump
			anim.SetTrigger("jump trigger");
			jumpedOnce = true;
		}
		else{
			// Attack
			anim.SetBool("isAttacking", true);
			attacker.Attack(obj);
		}
	}
}

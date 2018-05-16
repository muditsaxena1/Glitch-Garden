using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	[Tooltip ("Average number of seconds in appearances")]
	public float seenEverySecond;

	private GameObject currTarget;
	private float currSpeed;
	private Animator anim;


	void Start () {
		anim = this.GetComponent<Animator>();
	}


	void Update () {
		// Move the attacker towards left
		this.transform.Translate(Vector3.left * currSpeed * Time.deltaTime);
		if(!currTarget){
			// If there is no currTarget(maybe destroyed) then set attacker to not attacking state
			anim.SetBool("isAttacking", false);
		}
	}

	public void SetSpeed(float speed){
		currSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage){
		if (currTarget){
			Health health = currTarget.GetComponent<Health>();
			if (health){
				health.DealDamage(damage);
			}
		}
	}
	public void Attack(GameObject obj){
		currTarget = obj;
	}

}

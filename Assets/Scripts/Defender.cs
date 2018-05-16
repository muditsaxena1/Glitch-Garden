using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int starCost;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log(this.name + " trigger enter");
	}
	public void AddStars (int amount){
		print (amount);
		StarDisplay.AddStars(amount);
	}
}

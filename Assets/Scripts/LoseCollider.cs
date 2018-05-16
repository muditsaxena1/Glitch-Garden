using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelmanager;
	// Use this for initialization
	void Start () {
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
		if (!levelmanager){
			Debug.LogError("LevelManager not found");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collider){
		levelmanager.LoadLevel("03b Lose");
	}
}

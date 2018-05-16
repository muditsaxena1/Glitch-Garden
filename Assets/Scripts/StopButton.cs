using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour {

	LevelManager levelManager;

	void OnMouseDown(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("01a Start");
	}
}

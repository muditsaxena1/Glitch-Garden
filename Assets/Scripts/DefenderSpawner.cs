using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera gameCamera;

	private GameObject defenderParent;

	void Start () {
		defenderParent = GameObject.Find ("Defenders");
		if (!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
	}

	void OnMouseDown(){
		// if no defender button is selected
		if(!Button.selectedDefender){
			return;
		}

		// gets the starCost from Defender script
		int currStarCost = Button.selectedDefender.GetComponent<Defender>().starCost;

		// if currency is less than the cost
		if (StarDisplay.GetStarCount() < currStarCost){
			Debug.Log("Not enough sunlight!!");
			return;
		}

		//deduct the star cost of the current defender
		StarDisplay.UseStars(currStarCost);

		GameObject defender = Instantiate(Button.selectedDefender,SnapToGrid(CalculateWorldPointOfMouseClick()), 
		                                  Quaternion.identity) as GameObject;
		defender.transform.parent = defenderParent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);

		Vector2 worldPos = gameCamera.ScreenToWorldPoint(weirdTriplet);
		return worldPos;
	}

	Vector2 SnapToGrid(Vector2 worldPos){
		worldPos.x = Mathf.Round(worldPos.x);
		worldPos.y = Mathf.Round(worldPos.y);
		return worldPos;
	}
}

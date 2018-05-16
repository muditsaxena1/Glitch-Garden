using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	[SerializeField]
	private Button[] buttonArray;
	private Color blackColor;
	private Text costText;
	private Defender myDefender;

	void Start () {
		blackColor.r = 0.5f;
		blackColor.g = 0.5f;
		blackColor.b = 0.5f;
		blackColor.a = 1f;
		buttonArray = GameObject.FindObjectsOfType<Button>();

		costText = this.GetComponentInChildren<Text>();
		myDefender = defenderPrefab.GetComponent<Defender>();

		if (!costText){
			Debug.LogWarning("404 Cost Text not found for " + this.name);
		}

		costText.text = myDefender.starCost.ToString();
	}

	void OnMouseDown(){
		foreach(Button thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = blackColor;
		}
		this.GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}

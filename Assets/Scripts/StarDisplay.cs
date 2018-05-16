using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {
	public int startingCurrency = 150;

	private static int starCount = 0;
	private static Text starText;
	// Use this for initialization
	void Start () {
		starText = this.GetComponent<Text>();
		starCount = startingCurrency;	// starting currency
		starText.text = starCount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void AddStars(int amount){
		print (amount + " stars added to display");
		starCount += amount;
		UpdateStarCount ();
	}
	public static void UseStars(int amount){
		print (amount + " stars subtracted");
		starCount -= amount;
		UpdateStarCount ();
	}

	static void UpdateStarCount (){
		starText.text = starCount.ToString ();
	}

	public static int GetStarCount(){
		return starCount;
	}
}

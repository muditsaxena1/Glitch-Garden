using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
	public float levelSeconds = 100;

	private AudioSource audioSource;
	private LevelManager levelManager;
	private Slider slider;
	private bool isEndOfLevel = false;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		slider = this.GetComponent<Slider>();
		audioSource = this.GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindYouWin ();
		winLabel.SetActive(false);
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please add a You Win game object");
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel){
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects();
		winLabel.SetActive (true);
		audioSource.Play ();
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	void DestroyAllTaggedObjects(){
		GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("destroyOnWin");

		foreach (GameObject currGameObject in gameObjectArray){
			Destroy(currGameObject);
		}
	}

	void LoadNextLevel(){
		levelManager.LoadNextLevel();
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start(){
		if(autoLoadNextLevelAfter <= 0){
			Debug.Log("Autoload disabled");
		}
		else{
			Invoke("LoadNextLevel", autoLoadNextLevelAfter);
		}

	}

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for " + name );
		SceneManager.LoadScene(name);
	}
	
	public void QuitRequest() {
		Debug.Log("Quit Requested");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
		//SceneManager.LoadScene();
	}
}

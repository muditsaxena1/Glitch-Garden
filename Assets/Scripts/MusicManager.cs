using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
		Debug.Log("Dont destroy on load:" + name);
	}

	void Start () {
		audioSource = this.GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}

	void OnLevelWasLoaded (int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		if(thisLevelMusic){// if there is some music
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}

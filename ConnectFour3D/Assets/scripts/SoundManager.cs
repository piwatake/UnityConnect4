using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource fxSource;

	public static SoundManager instance = null;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	
	}

	public void PlaySingle(AudioClip clip){

		fxSource.clip = clip;
		fxSource.Play();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public AudioClip alarmSound;
	public AudioClip Music;
	public AudioClip buttonSound;

	public AudioSource musicSource;
	public AudioSource alarmButton;


	// This is a class to hold various game-state variables

	public bool isThereAFire = false;
	public bool isTheAlarmOn = false;


	void Start(){
		musicSource.clip = Music;
		musicSource.Play ();
		alarmButton.clip = buttonSound;
	}


	void Update(){
		if (isTheAlarmOn && musicSource.clip != alarmSound) {
			alarmButton.Play ();
			musicSource.Stop ();
			musicSource.clip = alarmSound;
			musicSource.Play ();
		}

		if (!isTheAlarmOn && musicSource.clip != Music) {
			musicSource.Stop ();
			musicSource.clip = Music;
			musicSource.Play ();
		}
	}
}

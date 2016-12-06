using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

	// This is a class to hold various game-state variables

	public bool isThereAFire = false;
	public bool isTheAlarmOn = false;
	public bool mute;

	public AudioClip alarmSound;
	public AudioClip Music;
	public AudioClip buttonSound;

	public AudioSource musicSource;
	public AudioSource alarmButton;

	[SerializeField]
	private AudioMixerGroup masterMixer;

	public void muteSound ()  {
		masterMixer.audioMixer.SetFloat ("MasterVolume", -80f);
	}

	public void unmuteSound(){
		masterMixer.audioMixer.SetFloat ("MasterVolume", 0f);
	}

	void Start(){
		musicSource.clip = Music;
		musicSource.Play ();
		alarmButton.clip = buttonSound;
	}

	void TriggerMute(){


		if (mute) {
			//Debug.Log ("unmute");
			unmuteSound ();
		} else {
			//Debug.Log ("mute");
			muteSound ();
		}
		mute = !mute;
	}

	void Update(){
		if(Input.GetKeyUp(KeyCode.M)){TriggerMute ();}
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

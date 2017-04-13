using UnityEngine;
using System.Collections;

public class questSoundPlayer : MonoBehaviour {

	public AudioSource audio;

	public AudioClip coffee;
	public AudioClip[] npc; 
	public AudioClip paper;
	public AudioClip quest;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void PlayCoffeeSound()
	{
		audio.clip = coffee;
		audio.Play ();
		Debug.Log ("Coffee sound");
	}

	public void PlayPaperSound()
	{
		audio.clip = paper;
		audio.Play ();
		Debug.Log ("Paper sound");
	}

	public void PlayNPCSound()
	{
		if (npc.Length > 0) {
			audio.PlayOneShot (npc [Random.Range (0, npc.Length)]);
			Debug.Log ("NPC sound");
		}


	}

	public void PlayQuestSound()
	{
		audio.clip = quest;
		audio.Play ();
		Debug.Log ("Quest sound");
	}
}

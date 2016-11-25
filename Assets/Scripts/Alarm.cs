using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {

	GameObject [] alarmBoxes;

	public bool triggered = false;
	public GameObject gameManager;

	private int i;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			triggered = true;
			gameManager.GetComponent<GameManager> ().isTheAlarmOn = true;
			alarmBoxes = GameObject.FindGameObjectsWithTag ("Alarm");
			for (i = 0; i < alarmBoxes.Length; i++) {
				alarmBoxes [i].GetComponent<Collider> ().enabled = false;
			}
		}
	}
}

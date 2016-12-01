using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {

	GameObject [] alarmBoxes;

	public bool triggered = false;
	public GameObject gameManager;

	private int i;

	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
			triggered = true;
			gameManager.GetComponent<GameManager> ().isTheAlarmOn = true;

			// Disable all the alarm triggers
			alarmBoxes = GameObject.FindGameObjectsWithTag ("Alarm");
			for (i = 0; i < alarmBoxes.Length; i++) {
				alarmBoxes [i].GetComponent<Collider> ().enabled = false;
			}
		}
	}
}

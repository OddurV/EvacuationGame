using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Alarm : MonoBehaviour {

	GameObject [] alarmBoxes;

	public bool triggered = false;
	public GameObject gameManager;
	public LevelEndFail levelEndFail;
	public Text reason;
	public Transform alarmFail;
	private int i;

	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
			triggered = true;
			gameManager.GetComponent<GameManager> ().isTheAlarmOn = true;
			if(!gameManager.GetComponent<GameManager> ().isThereAFire){
				
				//reason.text = "False alarm!";
				alarmFail.gameObject.SetActive(true);

				levelEndFail.Fail ();
			}
			// Disable all the alarm triggers
			alarmBoxes = GameObject.FindGameObjectsWithTag ("Alarm");
			for (i = 0; i < alarmBoxes.Length; i++) {
				alarmBoxes [i].GetComponent<Collider> ().enabled = false;
			}
		}
	}
}

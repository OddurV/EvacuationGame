using UnityEngine;
using System.Collections;

public class StartAlarm : MonoBehaviour {

	public GameObject gameManager;

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			gameManager.GetComponent<GameManager> ().isTheAlarmOn = true;
		}
	}

}

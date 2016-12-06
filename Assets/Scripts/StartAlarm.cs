using UnityEngine;
using System.Collections;

public class StartAlarm : MonoBehaviour {

	public GameObject gameManager;

	void OnTriggerEnter (Collider other){
		gameManager.GetComponent<GameManager> ().isTheAlarmOn = true;
	}

}

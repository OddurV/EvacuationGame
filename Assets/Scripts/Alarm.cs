using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour {

	GameObject [] alarmBoxes;

	private int i;

	void OnTriggerEnter(Collider other){
		Debug.Log ("Triggered!!!!!");
		alarmBoxes = GameObject.FindGameObjectsWithTag ("Alarm");

		for ( i = 0; i < alarmBoxes.Length; i++ ){
			alarmBoxes[i].GetComponent<Collider>().enabled = false;
		}
	}
}

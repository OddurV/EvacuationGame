using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class MoveAI : MonoBehaviour {

	public Alarm [] alarm;
	public Rigidbody rb;
	private int i ;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (i = 0; i < alarm.Length; i++) {
			if (alarm[i].triggered == true) {
				rb.isKinematic = false;
				this.GetComponent<AICharacterControl>().enabled = true;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class HoldCharacter : MonoBehaviour {

	//public float offset;

	void OnTriggerEnter(Collider other){
		//other.transform.parent = gameObject.transform;
		//offset = other.transform.position.y - gameObject.transform.position.y; // When this code is run, the offset is -1.45 on the first floor. 
	}

	void OnTriggerExit(Collider other){
		//other.transform.parent = null;
	}

	void OnTriggerStay(Collider other){
		Vector3 temp = other.transform.position;
		temp.y = gameObject.transform.position.y - 1.45f;//+offset;
		other.transform.position = temp;
	}
}

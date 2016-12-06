using UnityEngine;
using System.Collections;

public class StartFire : MonoBehaviour {

	public GameObject fireManager;

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			fireManager.GetComponent<FireStart> ().StartFire ();
		}
	}

}

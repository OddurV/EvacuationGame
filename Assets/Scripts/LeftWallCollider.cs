using UnityEngine;
using System.Collections;

public class LeftWallCollider : MonoBehaviour {

	public GameObject fireManager;

	void OnTriggerEnter(Collider other) {


		if(other.gameObject.tag == "Smoke")
			fireManager.GetComponent<FireStart>().isReachingLeftWall = true;
	}
}

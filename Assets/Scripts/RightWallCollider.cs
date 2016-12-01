using UnityEngine;
using System.Collections;

public class RightWallCollider : MonoBehaviour {

	public GameObject fireManager;

	void OnTriggerEnter(Collider other) {
		

		if(other.gameObject.tag == "Smoke")
			fireManager.GetComponent<FireStart>().isReachingRightWall = true;
	}
}

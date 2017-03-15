using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public float AngleY;

	private float targetValue = 0f;
	private float currentValue = 0f;
	private float easing = 0.05f;
	private bool smokeOnTheLeftBlocked = false;
	private bool smokeOnTheRightBlocked = false;

	public AudioSource audio;
	public GameObject fireManager;

	// Update is called once per frame
	void Update () {
		currentValue = currentValue + (targetValue - currentValue) * easing;
		transform.rotation = Quaternion.identity;
		transform.Rotate(0, currentValue, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Smoke" && targetValue != AngleY) {
			if (other.transform.position.z > this.transform.position.z) {
				fireManager.GetComponent<FireStart>().isReachingLeftWall = true;
				smokeOnTheRightBlocked = true;
			} else {
				fireManager.GetComponent<FireStart>().isReachingRightWall = true;
				smokeOnTheLeftBlocked = true;
			}
		}else{
            targetValue = AngleY;
        //currentValue = 0;
			if (smokeOnTheRightBlocked) {
				fireManager.GetComponent<FireStart>().isReachingLeftWall = false;
				smokeOnTheRightBlocked = false;
			}
			if(smokeOnTheLeftBlocked){
				fireManager.GetComponent<FireStart>().isReachingRightWall = false;
				smokeOnTheLeftBlocked = false;
			}
		}
    }

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetKeyDown (KeyCode.Space)) {
			//currentValue = AngleY;
			targetValue = 0;
			audio.Play (); 
		}
	}
}

using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public float AngleY;

	private float targetValue = 0f;
	private float currentValue = 0f;
	private float easing = 0.05f;

	// Update is called once per frame
	void Update () {
		currentValue = currentValue + (targetValue - currentValue) * easing;
		transform.rotation = Quaternion.identity;
		transform.Rotate(0, currentValue, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		targetValue = AngleY;
		//currentValue = 0;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetKeyDown (KeyCode.Space)) {
			//currentValue = AngleY;
			targetValue = 0;
		}
	}
}

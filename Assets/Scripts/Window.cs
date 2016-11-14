using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

	public float AngleY;

	private float targetValue = 0f;
	private float currentValue = 180f;
	private float easing = 0.05f;

	void Update () {
		currentValue = currentValue + (targetValue - currentValue) * easing;
		transform.rotation = Quaternion.identity;
		transform.Rotate(0, 0, currentValue);
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Closed!!!!!");
		GetComponent<Collider>().enabled = false;
		targetValue = AngleY;
		currentValue = 0;
	}
}

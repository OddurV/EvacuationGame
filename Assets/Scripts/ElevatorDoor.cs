using UnityEngine;
using System.Collections;

public class ElevatorDoor : MonoBehaviour {

	public ElevatorController elevatorController;
	public Transform door;
	public Transform position1;
	public Transform position2;
	public Vector3 newPosition;
	public float smooth;
	public int floor;

	void Start(){
		newPosition = position1.position;
	}

	void FixedUpdate () {
		door.position = Vector3.Lerp (door.position, newPosition, smooth * Time.deltaTime);
	}

	public void OpenDoor(){
		newPosition = position2.position;
	}

	public void CloseDoor(){
		newPosition = position1.position;
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space)) {
			elevatorController.Summon (floor);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			newPosition = position1.position;
		}
	}
}

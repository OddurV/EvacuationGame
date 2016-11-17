using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour {

	public Transform elevator;
	public Transform position1;
	public Transform position2;
	public Transform position3;
	public Transform position4;
	public Transform position5;
	public Vector3 newPosition;
	public string currentState; //should be private, is public now for debug purposes
	public float smooth;
	public float resetTime;
	private int targetFloor = 1;

	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	public GameObject door4;
	public GameObject door5;

	// Use this for initialization
	void Start () {
		//eDoors = GameObject.FindGameObjectsWithTag ("ElevatorDoor");
		//ChangeTarget();
		Summon(1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		elevator.position = Vector3.Lerp (elevator.position, newPosition, smooth * Time.deltaTime);
		CloseAll ();
		if (Mathf.Abs (elevator.position.y - newPosition.y) <= 0.3) {
			switch (targetFloor) {
			case 5:
				door5.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			case 4:
				door4.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			case 3:
				door3.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			case 2:
				door2.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			case 1:
				door1.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			default:
				door1.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			}
		}
	}

	void CloseAll(){
		door1.GetComponent<ElevatorDoor>().CloseDoor ();
		door2.GetComponent<ElevatorDoor>().CloseDoor ();
		door3.GetComponent<ElevatorDoor>().CloseDoor ();
		door4.GetComponent<ElevatorDoor>().CloseDoor ();
		door5.GetComponent<ElevatorDoor>().CloseDoor ();
	}
	/*void ChangeTarget(){
		if(currentState == "Moving To Position 1"){
			currentState = "Moving To Position 2";
			newPosition = position2.position;
		}
		else if(currentState == "Moving To Position 2"){
			currentState = "Moving To Position 1";
			newPosition = position1.position;
		}
		else if(currentState == ""){
			currentState = "Moving To Position 2";
			newPosition = position2.position;
		}
		Invoke ("ChangeTarget", resetTime);
	}*/

	public void Summon(int floor){
		switch (floor) {
		case 5:
			currentState = "Moving To Position 5";
			newPosition = position5.position;
			targetFloor = 5;
			break;
		case 4:
			currentState = "Moving To Position 4";
			newPosition = position4.position;
			targetFloor = 4;
			break;
		case 3:
			currentState = "Moving To Position 3";
			newPosition = position3.position;
			targetFloor = 3;
			break;
		case 2:
			currentState = "Moving To Position 2";
			newPosition = position2.position;
			targetFloor = 2;
			break;
		case 1:
			currentState = "Moving To Position 1";
			newPosition = position1.position;
			targetFloor = 1;
			break;
		default:
			currentState = "Moving To Position 1";
			newPosition = position1.position;
			targetFloor = 1;
			break;
		}
	}
}

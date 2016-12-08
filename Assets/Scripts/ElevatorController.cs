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
	public bool playerIsInElevator = false; //should be private, is public now for debug purposes

	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	public GameObject door4;
	public GameObject door5;

	public GameObject gameManager;

	public AudioClip elevatorSound;
	public AudioClip elevatorButtonSound;
	public AudioClip elevatorDoorSound;
	public AudioSource elevatorSoundSource;
	public AudioSource elevatorButtonSoundSource;
	public AudioSource elevatorDoorSoundSource;


	// Use this for initialization
	void Start () {
		// Make sure the elevator starts on the first floor
		Summon(1);
		// Set up the audio
		elevatorSoundSource.clip = elevatorSound;
		elevatorButtonSoundSource.clip = elevatorButtonSound;
		elevatorDoorSoundSource.clip = elevatorDoorSound;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Move the elevator
		elevator.position = Vector3.Lerp (elevator.position, newPosition, smooth * Time.deltaTime);

		// Close all the elevator doors
		CloseAll ();

		// Deactivate the elevator during a fire
		if (gameManager.GetComponent<GameManager> ().isThereAFire && !playerIsInElevator) {return;}

		// Play the elevator movement sound
		//elevatorSoundSource.Play();

		// Open the door where the elevator is
		if (Mathf.Abs (elevator.position.y - newPosition.y) <= 0.3) {

			// Stop the elevator movement sound
			//elevatorSoundSource.Stop();
			// Play the door opening sound
			//elevatorDoorSoundSource.Play();

			switch (targetFloor) {
			case 5:
				if (!door5.GetComponent<ElevatorDoor> ().openSoundPlayed) {
					elevatorDoorSoundSource.Play();
				}
				door5.GetComponent<ElevatorDoor> ().OpenDoor ();
				break;
			case 4:
				if (!door5.GetComponent<ElevatorDoor> ().openSoundPlayed) {
					elevatorDoorSoundSource.Play();
				}
				door4.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			case 3:
				if (!door5.GetComponent<ElevatorDoor> ().openSoundPlayed) {
					elevatorDoorSoundSource.Play();
				}
				door3.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			case 2:
				if (!door5.GetComponent<ElevatorDoor> ().openSoundPlayed) {
					elevatorDoorSoundSource.Play();
				}
				door2.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			case 1:
				if (!door5.GetComponent<ElevatorDoor> ().openSoundPlayed) {
					elevatorDoorSoundSource.Play();
				}
				door1.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			default:
				if (!door5.GetComponent<ElevatorDoor> ().openSoundPlayed) {
					elevatorDoorSoundSource.Play();
				}
				door1.GetComponent<ElevatorDoor>().OpenDoor ();
				break;
			}
		}
	}

	// Make the elevator recognize key commands
	void OnTriggerStay (Collider other){
		if (other.tag == "Player") {
			if(Input.GetKeyUp(KeyCode.Keypad1) || Input.GetKeyUp(KeyCode.Alpha1)){
				Debug.Log ("Key 1 pressed");
				Summon (1);
			}
			if(Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.Alpha2)){
				Debug.Log ("Key 2 pressed");
				Summon (2);
			}
			if(Input.GetKeyUp(KeyCode.Keypad3) || Input.GetKeyUp(KeyCode.Alpha3)){
				Debug.Log ("Key 3 pressed");
				Summon (3);
			}
			if(Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.Alpha4)){
				Debug.Log ("Key 4 pressed");
				Summon (4);
			}
			if(Input.GetKeyUp(KeyCode.Keypad5) || Input.GetKeyUp(KeyCode.Alpha5)){
				Debug.Log ("Key 5 pressed");
				Summon (5);
			}
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			playerIsInElevator = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.tag == "Player") {
			playerIsInElevator = false;
			if (gameManager.GetComponent<GameManager> ().isThereAFire) {
				CloseAll ();
			}
		}
	}

	// Close all the elevator doors
	void CloseAll(){
		door1.GetComponent<ElevatorDoor>().CloseDoor ();
		door2.GetComponent<ElevatorDoor>().CloseDoor ();
		door3.GetComponent<ElevatorDoor>().CloseDoor ();
		door4.GetComponent<ElevatorDoor>().CloseDoor ();
		door5.GetComponent<ElevatorDoor>().CloseDoor ();
	}

	// Summon the elevator to a specific floor
	public void Summon(int floor){
		// Play the elevator button sound
		elevatorButtonSoundSource.Play();

		if (gameManager.GetComponent<GameManager> ().isThereAFire) {return;}
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

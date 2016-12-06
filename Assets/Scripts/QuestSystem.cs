using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class QuestSystem : MonoBehaviour {

    public ScoreManager scManager;
    public Text messageText;
	public GameObject[] quests;
	public int questCounter = 0;
	public GameObject fireManager;
	public Camera mainCamera;
	private Transform target; // Target to point at
	private Vector3 targetPos;
	private Vector3 screenMiddle;
	public AudioSource questSource; 
	//public AudioClip questPickup;
	private bool finished = false;

	//Quest Icons
	public GameObject arrow;
	//public GameObject exitSign;
	public GameObject questMarker;
	/*public GameObject alert;
	public GameObject coffee;
	public GameObject letter;
	public GameObject speechCoffee;
	public GameObject speechRun;
	public GameObject speechLetter;
*/
	void Start(){
		quests = GameObject.FindGameObjectsWithTag ("Quest").OrderBy( go => go.name ).ToArray();
		// Deactivate all quests
		for (int i = 0; i < quests.Length; i++) {
			//Debug.Log ("Quest Number " + i + " is named" + quests [i].name);
			quests [i].SetActive (false);
		}
		// Activate the first quest
		quests [0].SetActive (true);
		messageText.text = "Go to "+quests[0];

	}

	// This update function places the quest icons on the screen
	void Update(){
		if (finished) {
			return;
		}
		if(questCounter >= quests.Length){
			finished = true;
			arrow.SetActive (false);
			questMarker.SetActive (false);
			return;
		}

		// Get the screen's center
		Vector3 screenCenter = new Vector3(Screen.width, Screen.height, 0)/2;
		// Set the target
		target = quests[questCounter].transform;
		// Get the targets position on screen into a Vector3
		targetPos = mainCamera.WorldToScreenPoint(target.transform.position);
		//Debug.Log ("targetPos: "+targetPos);
		// Check if the target is on-screen
		if (targetPos.z > 0 &&
		    targetPos.x > 0 && targetPos.x < Screen.width &&
		    targetPos.y > 0 && targetPos.y < Screen.height) {

			questMarker.transform.localPosition = targetPos-screenCenter;
			//Debug.Log (quests[questCounter]+" is on-screen");
			// Deactivate te arrow
			arrow.SetActive(false);
		} else {// target is off-screen
			//Debug.Log (quests[questCounter]+" is off-screen");
			if(targetPos.z<0){targetPos *= -1;} //Not sure if this is necessary in this game bacause the camera doesn't rotate

			// Translating coordinates
			// Making the origin be the center of the screen instead of the bottom left corner
			targetPos -= screenCenter;

			// find angle from center of screen to mouse position
			float angle = Mathf.Atan2(targetPos.y, targetPos.x);
			angle -= 90 * Mathf.Deg2Rad;

			float cos = Mathf.Cos (angle);
			float sin = -Mathf.Sin (angle);

			targetPos = screenCenter + new Vector3 (sin * 150, cos * 150, 0);

			// y = mx+b format
			float m = cos / sin;

			Vector3 screenBounds = screenCenter * 0.9f;

			// check up and down first
			if (cos > 0) {
				targetPos = new Vector3 (screenBounds.y / m, screenBounds.y, 0);
			} else {
				//down
				targetPos = new Vector3 (-screenBounds.y / m, -screenBounds.y, 0);
			}
			// if out of bounds, get point on appropriate side
			if (targetPos.x > screenBounds.x) {//out of bounds! must be on the right
				targetPos = new Vector3 (screenBounds.x, screenBounds.x * m, 0);
			} else if (targetPos.x < -screenBounds.x) {//out of bounds left
				targetPos = new Vector3 (-screenBounds.x, -screenBounds.x * m, 0);
			}//else in bounds

			// Activate the arrow
			arrow.SetActive(true);
			// set the arrow's position and rotation
			arrow.transform.localPosition = targetPos;
			arrow.transform.localRotation = Quaternion.Euler (0, 0, (angle-90) * Mathf.Rad2Deg);
			// set the quest marker's position
			questMarker.transform.localPosition = targetPos;
		}
	}

	//Use:  QuestCompleted()
	//Pre:  questCounter is an int representing how many quests have been completed
	//		quests is an array of quest gameObjects
	//Post: The next quest has been activated
	public void QuestCompleted(){
		Debug.Log ("Quest completed!");
		questCounter++;
        scManager.ScoreAddition();
		if (questCounter >= quests.Length) {
			messageText.text = "All quests completed";
			fireManager.GetComponent<FireStart> ().StartFire ();
			return;
		}
		quests [questCounter].SetActive (true);
		messageText.text = "Go to "+quests[questCounter];
		questSource.Play ();
	}
}
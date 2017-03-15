using UnityEngine;
using System.Collections;

public class FireStart : MonoBehaviour {

	public float timeRemaining = 40f;
	public GameObject fire;
	public GameObject smoke;
	public bool isReachingRightWall;
	public bool isReachingLeftWall;

	public Transform [] spawnFirePoints;
	public GameObject gameManager;

	public float smokeDelay = 0f;
	public float smokeRepeatDelay = 0.5f;
	public static int spreadDistanceRight = 0;
	public static int spreadDistanceLeft = 0;

	public Timer timerScript;

	// Use this for initialization
	void Start () {
		
		Invoke ("StartFire", timeRemaining);
		//smoke = Instantiate (Resources.Load ("Smoke", typeof(GameObject))) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	//The fire starts in a random predefined spawn point
	public void StartFire () {
		spreadDistanceRight = 0;
		spreadDistanceLeft = 0;
		gameManager.GetComponent<GameManager> ().isThereAFire = true;
		int spawnPointIndex = Random.Range (0, spawnFirePoints.Length);
		//int spawnPointIndex = 12;

		Instantiate (fire, spawnFirePoints[spawnPointIndex].position, spawnFirePoints[spawnPointIndex].rotation);
		Instantiate (smoke, spawnFirePoints[spawnPointIndex].position, smoke.transform.rotation);

		InvokeRepeating ("SpreadFire", smokeDelay, smokeRepeatDelay);

		timerScript.Reset();
	}


	void SpreadFire() {
		
		GameObject respawn;
		Vector3 newPositionRight;
		Vector3 newPositionLeft;
	
		if (!isReachingRightWall) {
			spreadDistanceRight += 4;
		}
		if (!isReachingLeftWall) {
			spreadDistanceLeft += 4;
		}
		//Looking for the fire spot
		respawn = GameObject.FindGameObjectWithTag("Fire");

		//Adding smoke in each side of the first fire spot

		newPositionRight = respawn.transform.position + new Vector3 (0f, 0f, spreadDistanceRight);
		newPositionLeft = respawn.transform.position - new Vector3 (0f, 0f, spreadDistanceLeft);

		//Delimits the smoke spreading for the right wall
		if (!isReachingRightWall)
			Instantiate (smoke, newPositionRight, smoke.transform.rotation);

		//Delimits the smoke spreading for the left wall
		if (!isReachingLeftWall)
			Instantiate (smoke, newPositionLeft, smoke.transform.rotation);
	}

}

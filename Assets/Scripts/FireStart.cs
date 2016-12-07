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




	public static int spreadDistance = 0;

	// Use this for initialization
	void Start () {
		
		Invoke ("StartFire", timeRemaining);
		smoke = Instantiate (Resources.Load ("Smoke", typeof(GameObject))) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	//The fire starts in a random predefined spawn point
	public void StartFire () {
		spreadDistance = 0;
		gameManager.GetComponent<GameManager> ().isThereAFire = true;
		int spawnPointIndex = Random.Range (0, spawnFirePoints.Length);
		//int spawnPointIndex = 12;

		Instantiate (fire, spawnFirePoints[spawnPointIndex].position, spawnFirePoints[spawnPointIndex].rotation);
		Instantiate (smoke, spawnFirePoints[spawnPointIndex].position, smoke.transform.rotation);

		InvokeRepeating ("SpreadFire", 10f, 1f);

	}


	void SpreadFire() {
		
		GameObject respawn;
		Vector3 newPositionRight;
		Vector3 newPositionLeft;
	

		spreadDistance += 2;
		//Looking for the fire spot
		respawn = GameObject.FindGameObjectWithTag("Fire");

		//Adding smoke in each side of the first fire spot

		newPositionRight = respawn.transform.position + new Vector3 (0f, 0f, spreadDistance);
		newPositionLeft = respawn.transform.position - new Vector3 (0f, 0f, spreadDistance);

		//Delimits the smoke spreading for the right wall
		if (!isReachingRightWall)
			Instantiate (smoke, newPositionRight, smoke.transform.rotation);

		//Delimits the smoke spreading for the left wall
		if (!isReachingLeftWall)
			Instantiate (smoke, newPositionLeft, smoke.transform.rotation);
	}

}

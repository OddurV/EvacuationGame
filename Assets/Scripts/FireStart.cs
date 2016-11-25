using UnityEngine;
using System.Collections;

public class FireStart : MonoBehaviour {

	public float timeRemaining = 40f;
	public GameObject fire;
	public GameObject smoke;
	public float spawnSmallFireTime = 15f;
	public Transform [] spawnFirePoints;

	public GameObject respawnPrefab;
	public GameObject respawn;

	// Use this for initialization
	void Start () {
		
		Invoke ("StartFire", timeRemaining);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	//The fire starts in a random predefined spawn point
	void StartFire () {
		int spawnPointIndex = Random.Range (0, 5);
		Instantiate (fire, spawnFirePoints[spawnPointIndex].position, spawnFirePoints[spawnPointIndex].rotation);
		Instantiate (smoke, spawnFirePoints[spawnPointIndex].position, spawnFirePoints[spawnPointIndex].rotation);
		Invoke ("SpreadFire", 2f);
	}

	void SpreadFire() {
		if (respawn == null)
			respawn = GameObject.FindWithTag("Smoke");

		Debug.Log (respawn.transform.position);

		Instantiate(respawnPrefab, respawn.transform.position = new Vector3(0,0,2), respawn.transform.rotation);
	}
}

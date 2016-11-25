using UnityEngine;
using System.Collections;

public class FireStart : MonoBehaviour {

	public float timeRemaining = 40f;
	public GameObject fire;
	public float spawnSmallFireTime = 15f;
	public Transform [] spawnFirePoints;

	// Use this for initialization
	void Start () {
		
		Invoke ("StartFire", timeRemaining);

	}
	
	// Update is called once per frame
	void Update () {
	}
		
	//The fire starts in a random predefined spawn point
	void StartFire () {
		int spawnPointIndex = Random.Range (0, spawnFirePoints.Length);
		Instantiate (fire, spawnFirePoints[spawnPointIndex].position, spawnFirePoints[spawnPointIndex].rotation);
	}

}

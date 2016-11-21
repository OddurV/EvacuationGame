using UnityEngine;
using System.Collections;

public class FireStart : MonoBehaviour {

	public float timeRemaining = 40f;
	public GameObject smallFire;
	public float spawnSmallFireTime = 10;
	public Transform [] spawnFirePoints;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("SpawnSmallFire", timeRemaining, spawnSmallFireTime);

	}
	
	// Update is called once per frame
	void Update () {
	}

	void StartFire() {
		Debug.Log ("StartFire!", gameObject);
		SpawnSmallFire ();
	}

	void SpawnSmallFire () {
		int spawnPointIndex = Random.Range (0, spawnFirePoints.Length);
		Instantiate (smallFire, spawnFirePoints[spawnPointIndex].position, spawnFirePoints[spawnPointIndex].rotation);
	}
}

using UnityEngine;
using System.Collections;

public class FireStart : MonoBehaviour {

	public float timeRemaining = 40f;
	public GameObject fire;
	public Transform [] spawnFirePoints;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
		
		Invoke ("StartFire", timeRemaining);

	}
	
	// Update is called once per frame
	void Update () {
	}
		
	//The fire starts in a random predefined spawn point
	public void StartFire () {
		gameManager.GetComponent<GameManager> ().isThereAFire = true;
		int spawnPointIndex = Random.Range (0, spawnFirePoints.Length);
		Instantiate (fire, spawnFirePoints[spawnPointIndex].position, spawnFirePoints[spawnPointIndex].rotation);
	}

}

using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class MoveAI : MonoBehaviour {

	public GameObject gameManager;
	public Alarm [] alarm;
	public Rigidbody rb;
	private int i ;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.GetComponent<GameManager> ().isTheAlarmOn) {
			rb.isKinematic = false;
			this.GetComponent<AICharacterControl>().enabled = true;
		}
	}
}

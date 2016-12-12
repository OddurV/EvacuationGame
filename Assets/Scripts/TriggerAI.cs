using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class TriggerAI : MonoBehaviour {

	public Rigidbody rb;
	public GameObject gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
		if (other.tag == "Player" 
			&& gameManager.GetComponent<GameManager> ().isTheAlarmOn 
			/*&& Input.GetKeyDown(KeyCode.Space)*/)
        {
			rb.isKinematic = false;
            this.GetComponent<AICharacterControl>().enabled = true;
        }
    }
}

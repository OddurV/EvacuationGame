using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class TriggerAI : MonoBehaviour {

	public GameObject gameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player" && gameManager.GetComponent<GameManager> ().isTheAlarmOn)
        {
            this.GetComponent<AICharacterControl>().enabled = true;
        }
    }
}
